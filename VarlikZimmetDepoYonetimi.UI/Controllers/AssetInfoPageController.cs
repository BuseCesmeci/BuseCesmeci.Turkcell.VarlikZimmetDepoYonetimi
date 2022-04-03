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

        public async Task<IActionResult> Index()
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
        [HttpGet]
        public async Task<IActionResult> RegistrationInfo(int id) // kayıt bilgileri
        {
            var uptvalue = await _assetProvider.GetAssetByIDAsync(id);

            return View(uptvalue);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationInfo(AssetAddDTO assetDto) // kayıt bilgileri
        {
            var value = await _assetProvider.GetAssetDetailAsync();
            assetDto.AssetType = value.AssetType;
            assetDto.Brand = value.Brand;
            assetDto.Model = value.Model;
            assetDto.Currency = value.Currency;

            //var value = assetVm.AssetType;
            var request = new AssetDTO();
            request.AssetID = assetDto.AssetID;
            request.AssetTypeID = assetDto.SelectedAssetType;
            request.BrandModelID = assetDto.SelectedBrand;
            request.Cost = assetDto.Cost;
            request.Description = assetDto.Description;
            request.RegistrationNumber = assetDto.RegistrationNumber;
            request.RetireDate = DateTime.Now;

            //var barcode = new AssetBarcodeDTO();
            //barcode.AssetID = assetVm.AssetID;
            //barcode.Barcode = assetVm.Barcode;

            //var price = new PriceDTO();
            //price.AssetID = assetVm.AssetID;
            //price.AssetPrice = assetVm.AssetPrice;

            //var status = new AssetStatusDTO();
            //status.AssetID = assetVm.AssetID;
            //status.StatuID = 1;

            await _assetProvider.UpdateAsync(request);
            return View(assetDto);
        }
        public IActionResult KarekodInfo() // Karekod Bilgileri
        {
            return View();
        }
        public IActionResult RegistrationHistory() // Kayıt Geçmişi (Log)
        {
            return View();
        }
        public IActionResult FormHistory() // Form Geçmişi (??)
        {
            return View();
        }
    }
}
