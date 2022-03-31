using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;
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
        [HttpPost]
        public async Task<IActionResult> AddAsset(AssetDTO assetDto) // varlık ekle -yeni kayıt-
        {
            await _assetProvider.AddAsync(assetDto);
            return Redirect("Index");
        }
        [HttpPost]
        public IActionResult AddAssetWithoutBarcode() // barkodsuz varlık ekle -yeni kayıt- 
        {
            return View();
        }
        [HttpPost]
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
