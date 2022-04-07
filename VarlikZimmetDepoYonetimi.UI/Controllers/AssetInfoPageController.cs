using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;
using VarlikZimmetDepoYonetimi.UI.Provider;

namespace VarlikZimmetDepoYonetimi.UI.Controllers
{
    public class AssetInfoPageController : Controller
    {
        // guncelleme yapılacak

        AssetProvider _assetProvider;
        public AssetInfoPageController(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegistrationInfo() // kayıt bilgileri
        {
           
            var assetlist = await _assetProvider.GetAssetAsync();

            var updvalue = await _assetProvider.GetAssetDetailAsync();
           
            //var getupdasset = await _assetProvider.GetAssetAsync();
            var update = new AssetUpdateDTO();
            update.Asset = assetlist;
            update.AssetGroup = updvalue.AssetGroup;
            update.AssetType = updvalue.AssetType;
            update.Brand = updvalue.Brand;
            update.Model = updvalue.Model;
            update.Currency = updvalue.Currency;
            // update.Asset = getupdasset;

            

            return View(update);

        }

        [HttpPost]
        public async Task<IActionResult> RegistrationInfo(AssetUpdateDTO assetDto) // kayıt bilgileri
        {
            var value = await _assetProvider.GetAssetDetailAsync();
            assetDto.AssetType = value.AssetType;
            assetDto.Brand = value.Brand;
            assetDto.Model = value.Model;
            assetDto.Currency = value.Currency;

            //var value = assetVm.AssetType;
            var request = new AssetDTO();
           // request.AssetID = assetDto.AssetID;
            request.AssetTypeID = assetDto.SelectedAssetType;
            request.BrandModelID = assetDto.SelectedBrand;
            request.Cost = assetDto.Cost;
            request.Description = assetDto.Description;
           // request.RegistrationNumber = assetDto.RegistrationNumber;
            request.RetireDate = DateTime.Now;

            //var barcode = new AssetBarcodeDTO();
            //barcode.AssetID = assetVm.AssetID;
            //barcode.Barcode = assetVm.Barcode;

            //var price = new PriceDTO();
            //price.AssetID = assetVm.AssetID;
            //price.AssetPrice = assetVm.AssetPrice;
           

            await _assetProvider.UpdateAsync(request);
            return View(assetDto);
        }
        public IActionResult KarekodInfo() // Karekod Bilgileri
        {
            return View();
        }
        public IActionResult RegistrationHistory() // Kayıt Geçmişi ()
        {
            return View();
        }
 
        public IActionResult FormHistory() // Form Geçmişi (??)
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormHistory(string a) // Form Geçmişi ()
        {
            return View();
        }
    }
}
