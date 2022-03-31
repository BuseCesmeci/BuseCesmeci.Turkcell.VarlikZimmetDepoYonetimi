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
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            await _tokenProvider.Token(username, password);
            return Redirect("AssetPage");
        }
        [HttpPost]
        public IActionResult ChangePassword() // sifre degistir
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register() // kayit ol
        {
            return View();
        }
    }
}
