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
        private readonly AssetProvider _assetProvider;
        private readonly AssetBarcodeProvider _barcodeProvider;
        private readonly AssetPriceProvider _priceProvider;
        private readonly AssetStatusProvider _statusProvider;
        private readonly GetAssetTableProvider _tableProvider;
        

        public AssetPageController(AssetProvider assetProvider, AssetBarcodeProvider assetBarcode, AssetPriceProvider priceProvider, AssetStatusProvider statusProvider, GetAssetTableProvider tableProvider)
        {
            _assetProvider = assetProvider;
            _barcodeProvider = assetBarcode;
            _priceProvider = priceProvider;
            _statusProvider = statusProvider;
            _tableProvider = tableProvider;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddAsset()         
        {
                        
            var value = await _assetProvider.GetAssetDetailAsync();
            var values = new AssetAddDTO();

            ViewData["AssetGroup"] = value.AssetGroup;
            ViewData["AssetType"] = value.AssetType;
            ViewData["Brand"] = value.Brand;
            ViewData["Model"] = value.Model;
            ViewData["Currency"] = value;

            values.AssetGroup = value.AssetGroup;
            values.AssetType = value.AssetType;
            values.Brand = value.Brand;
            values.Model = value.Model;
            values.Currency = value.Currency;

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsset(AssetAddDTO assetVm) // varlık ekle -yeni kayıt-
        {
           // if (ModelState.IsValid)
          //  {
            
                var value = await _assetProvider.GetAssetDetailAsync();

                assetVm.AssetGroup = value.AssetGroup;
                assetVm.AssetType = value.AssetType ;
                assetVm.Brand = value.Brand;
                assetVm.Model  = value.Model;
                assetVm.Currency = value.Currency;

                var request = new AssetDTO();
                request.AssetID = assetVm.AssetID;
                request.AssetGroupID = assetVm.SelectedAssetGroup;
                request.AssetTypeID = assetVm.SelectedAssetType;
                request.BrandModelID = assetVm.SelectedBrand;
                request.Cost = assetVm.Cost;
                request.Description = assetVm.Description;
                request.RegistrationNumber = assetVm.RegistrationNumber;
                request.RetireDate  = DateTime.Now;          

                await _assetProvider.AddVMAsync(request);
                var value2 = await _assetProvider.GetAssetAsync();
                assetVm.AssetID = value2.OrderByDescending(x => x.AssetID).FirstOrDefault().AssetID;

                var barcode = new AssetBarcodeDTO();
                barcode.AssetID = assetVm.AssetID;
                barcode.Barcode = assetVm.Barcode;

                var price = new PriceDTO();
                price.AssetID = assetVm.AssetID;
                price.AssetPrice = assetVm.AssetPrice;

                var status = new AssetStatusDTO();
                status.AssetID = assetVm.AssetID;
                status.StatuID = 1;

                await _barcodeProvider.AddBorcodeAsync(barcode);
                await _priceProvider.AddAssetPriceAsync(price);
                await _statusProvider.AddAssetStatusAsync(status);

            //}
            return View(assetVm);
           
        }

      
        public IActionResult AddAssetWithoutBarcode()  
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

            var value = await _tableProvider.GetAllAssetTableAsync();
            var list = new GetAssetTableDTO();

            return View(value);
        }
      
    }
}
