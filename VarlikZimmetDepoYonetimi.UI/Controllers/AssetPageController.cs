using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Controllers
{
    public class AssetPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      //  [HttpPost]
        public IActionResult AddAsset() // varlık ekle -yeni kayıt-
        {
            return View();
        }
       // [HttpPost]
        public IActionResult AddAssetWithoutBarcode() // barkodsuz varlık ekle -yeni kayıt- 
        {
            return View();
        }
        public IActionResult MyAsset() // varlıklarım
        {
            return View();
        }
        public IActionResult MyTeamAsset() // ekibimin varlıkları
        {
            return View();
        }
        public IActionResult AllAsset() // tüm varlıklar
        {
            return View();
        }
      
    }
}
