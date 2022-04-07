using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;
using VarlikZimmetDepoYonetimi.UI.Provider;
using VarlikZimmetDepoYonetimi.UI.CacheExtension;

namespace VarlikZimmetDepoYonetimi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        IDistributedCache _cache;
        AssetActionOptionsProvider _actionOptionsProvider;
        AssetActionProvider _actionProvider;
        AssetOwnerProvider _ownerProvider;
        AssetStatusProvider _statusProvider;
        OwnerTypeProvider _ownerTypeProvider;
        PersonnelProvider _personnelProvider;
        AssetProvider _assetProvider;

        public HomeController(IDistributedCache cache, AssetActionOptionsProvider optionProvider, AssetOwnerProvider ownerProvider, AssetStatusProvider statusProvider, AssetActionProvider actionProvider,
            OwnerTypeProvider ownerTypeProvider, PersonnelProvider personnelProvider, AssetProvider assetProvider)
        {
            _cache = cache;
            _actionOptionsProvider = optionProvider;
            _ownerProvider = ownerProvider;
            _statusProvider = statusProvider;
            _actionProvider = actionProvider;
            _ownerTypeProvider = ownerTypeProvider;
            _personnelProvider = personnelProvider;
            _assetProvider = assetProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAsset() => View();

        [HttpGet]
        public async Task<IActionResult> AssetDebit()
        {
            // zimmet çıkarma nedeni => actionoption >> tbl.AssetActionOption
            // Zimmet türü => persone, ekip >> tbl.OwnerType
            string location = "";
            string iscache = "";

         //   var ownertype = await _ownerTypeProvider.GetOwnerTypeAsync();

            string key = "ownerType_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            var cacheOwnerType = await _cache.GetRecordAsync<List<OwnerTypeDTO>>(key);

            if (cacheOwnerType is null)
            {
                cacheOwnerType = await _ownerTypeProvider.GetOwnerTypeAsync();
                await _cache.SetRecordAsync<List<OwnerTypeDTO>>(key, cacheOwnerType);
                location = $"API Data => {DateTime.Now}";
                iscache = "";
            }
            else
            {
                location = $"Cache Data => {DateTime.Now}";
                iscache = "text-danger";
            }
            ViewBag.location = location;
            ViewBag.text = iscache;

            var getasset = await _assetProvider.GetAssetAsync();

            var debit = new DebitDTO();
            debit.OwnerType = cacheOwnerType;
            debit.Asset = getasset;           
            return View(debit);
        }

        [HttpPost]
        public async Task<IActionResult> AssetDebit(DebitDTO debitDto)
        {

            var personnel = await _personnelProvider.GetAsync();
           
            var controlPersonnel = personnel.FindAll(x => x.PersonnelID == debitDto.PersonnelID).Count();

            if (controlPersonnel == 0)
            {
                return null;
            }
            else
            {
                var controlPersonnelTeam = personnel.FindAll(x => x.PersonnelID == debitDto.PersonnelID && x.UpperTeamMi == true).Count();

                if (controlPersonnelTeam == 0)
                {
                    debitDto.OwnerTypeID = 1;
                }
                else
                {
                    debitDto.OwnerTypeID = 2;
                }
                debitDto.OwnerID = debitDto.PersonnelID;
            }
            
            debitDto.AssetID = debitDto.SelectedAsset;
            var addOwner = await _ownerProvider.AddAssetOwnerAsync(debitDto);  // tbl.assetowner insert
            debitDto.StatuID = 2;
            var addValue = await _statusProvider.AddAssetStatusAsync(debitDto);   // tbl.assetStatus insert
                      
            return RedirectToAction("Admin/Home/AssetDebit");
        }

    }
}
