using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;
using VarlikZimmetDepoYonetimi.UI.Provider;

namespace VarlikZimmetDepoYonetimi.UI.Controllers
{
    public class ActionController : Controller
    {
        CommentProvider _commentProvider;

        public ActionController(CommentProvider commentProvider)
        {
            _commentProvider = commentProvider;
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

        public async Task<IActionResult> AddComment() // yorum ekle  
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentDTO commentDto) // yorum ekle  
        {
           await _commentProvider.AddCommentAsync(commentDto);

            return View(commentDto);
        }
    }
}
