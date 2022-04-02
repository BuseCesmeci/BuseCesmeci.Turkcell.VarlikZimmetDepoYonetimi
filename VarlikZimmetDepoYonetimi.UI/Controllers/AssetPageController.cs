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
            
            var value = await _assetProvider.GetAssetDetailAsync();
            var values = new AssetAddDTO();

            ViewData["AssetType"] = value.AssetType;
            ViewData["Brand"] = value.Brand;
            ViewData["Model"] = value.Model;
            ViewData["Currency"] = value;

            values.AssetType = value.AssetType;
            values.Brand = value.Brand;
            values.Model = value.Model;
            values.Currency = value.Currency;

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsset(AssetAddDTO assetVm) // varlık ekle -yeni kayıt-
        {
            var value = await _assetProvider.GetAssetDetailAsync();

            assetVm.AssetType = value.AssetType ;
            assetVm.Brand = value.Brand;
            assetVm.Model  = value.Model;
            assetVm.Currency = value.Currency;

            //var value = assetVm.AssetType;
            var request = new AssetDTO();
            request.AssetID = assetVm.AssetID;
            request.AssetTypeID = assetVm.SelectedAssetType;
            request.BrandModelID = assetVm.SelectedBrand;
            request.Cost = assetVm.Cost;
            request.Description = assetVm.Description;
            request.RegistrationNumber = assetVm.RegistrationNumber;
            request.RetireDate  = DateTime.Now;

            await _assetProvider.AddVMAsync(request);
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
