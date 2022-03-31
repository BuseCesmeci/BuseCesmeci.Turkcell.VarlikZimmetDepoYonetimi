using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Controllers
{
   
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register()
        {
            return View();
        }
    }
}
