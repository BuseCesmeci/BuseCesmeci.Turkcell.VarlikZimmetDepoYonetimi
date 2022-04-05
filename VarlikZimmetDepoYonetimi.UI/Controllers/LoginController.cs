using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Provider;

namespace VarlikZimmetDepoYonetimi.UI.Controllers
{
   
    public class LoginController : Controller
    {
        TokenProvider _tokenProvider;

        public LoginController(TokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var Login = await _tokenProvider.Token(username, password);

            if (Login == null || Login == "")
            {
                //message
                return Redirect("Login");
            }
            else
            {
                return RedirectToAction("AllAsset", "AssetPage", "username");
            } 
        }
       // [HttpPost]
        public IActionResult ChangePassword() // sifre degistir
        {
            return View();
        }
        //[HttpPost]
        public IActionResult Register() // kayit ol
        {
            return View();
        }
    }
}
