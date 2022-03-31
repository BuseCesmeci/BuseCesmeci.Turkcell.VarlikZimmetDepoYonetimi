using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Controllers
{
    public class AssetInfoPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult RegistrationInfo() // kayıt bilgileri
        {
            return View();
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
