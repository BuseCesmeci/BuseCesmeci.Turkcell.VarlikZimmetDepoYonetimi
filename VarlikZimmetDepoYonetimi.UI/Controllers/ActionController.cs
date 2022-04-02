using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Provider;

namespace VarlikZimmetDepoYonetimi.UI.Controllers
{
    public class ActionController : Controller
    {
        AssetProvider _assetProvider;

        public ActionController(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult AssignToStorage() // depoya ata
        {
            
            return View();
        }
        //[HttpPost]
        public IActionResult TakeOn() // ustlen
        {
            return View();
        }
        //[HttpPost]
        public IActionResult ToConsume() // tüket
        {
            return View();
        }
       // [HttpPost]
        public IActionResult AssetToReturn() // Iadet et
        {
            return View();
        }
       // [HttpPost]
        public IActionResult Abort() // iptal et
        {
            return View();
        }
        //[HttpPost]
        public IActionResult Superannuate() // emekli et
        {
            return View();
        }
        //[HttpPost]
        public IActionResult LossStolen() // kayip/calinti bildir
        {
            return View();
        }
        //[HttpPost]
        public IActionResult Debit() // zimmet ata
        {
            return View();
        }
       // [HttpPost]
        public IActionResult AddComment() // yorum ekle  
        {
            return View();
        }
    }
}
