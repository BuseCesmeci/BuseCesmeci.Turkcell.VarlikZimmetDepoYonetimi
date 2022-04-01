using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;
using VarlikZimmetDepoYonetimi.UI.Models.VM;
using VarlikZimmetDepoYonetimi.UI.Provider;

namespace VarlikZimmetDepoYonetimi.UI.Controllers
{
    public class AssetPageController : Controller
    {
        AssetProvider _assetProvider;

        public AssetPageController(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddAsset() 
        {
          //var value = await _assetProvider.Get();
         // List<AssetDetailListVM> valueList = new List<AssetDetailListVM>();
            var values = new AssetDetailListVM();
            //values.AssetType = new List<AssetTypeDTO>
            //{
            //    new AssetTypeDTO { AssetTypeID = 1, AssetTypeName = "Telefon" },
            ////};
            //values.AssetType = new List<SelectListItem>
            //{
            //    new SelectListItem { Text = "Telefon" , Value = "1" },
            //    new SelectListItem { Text = "Bilgisayar" , Value = "2" },
            //    new SelectListItem { Text = "Modem" , Value = "3" },
            //    new SelectListItem { Text = "Akıllı Saat" , Value = "4" },
            //    new SelectListItem { Text = "Kulaklık" , Value = "5" },
            //    new SelectListItem { Text = "Şarj Cihazı" , Value = "6" }
            //};

            
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsset(AssetDetailListVM assetVm) // varlık ekle -yeni kayıt-
        {
            //var value = assetVm.AssetType;
            await _assetProvider.AddVMAsync(assetVm);
            return View(assetVm);
           
        }

        //[HttpPost]
        //public async Task<IActionResult> AddAsset(AssetDTO assetDto) // varlık ekle -yeni kayıt-
        //{

        //    assetDto.RetireDate = DateTime.Now;
        //    await _assetProvider.AddAsync(assetDto);
        //    return View();
        //}
       // [HttpPost]
        public IActionResult AddAssetWithoutBarcode() // barkodsuz varlık ekle -yeni kayıt- 
        {
            return View();
        }
       // [HttpPost]
        public async Task<IActionResult> MyAsset(int personelID) // varlıklarım
        {
            await _assetProvider.GetAssetByIDAsync(personelID);
            return View();
        }
        public IActionResult MyTeamAsset() // ekibimin varlıkları
        {
            return View();
        }
        public async Task<IActionResult> AllAsset() // tüm varlıklar
        {
            await _assetProvider.GetAssetAsync();
            return View();
        }
      
    }
}
