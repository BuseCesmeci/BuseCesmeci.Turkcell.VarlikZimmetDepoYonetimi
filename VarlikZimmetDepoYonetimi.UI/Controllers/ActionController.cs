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
        
        AssetStatusProvider _statusProvider;
        CommentProvider _commentProvider;
        CustomerProvider _customerProvider;
        AssetActionOptionsProvider _actionOptionsProvider;
        PersonnelProvider _personnelProvider;
        CompanyProvider _companyProvider;
        AssetOwnerProvider _ownerProvider;

        public ActionController(AssetStatusProvider statusProvider, CommentProvider commentProvider, CustomerProvider customerProvider, AssetActionOptionsProvider actionOptionsProvider,
            PersonnelProvider personnelProvider, CompanyProvider companyProvider, AssetOwnerProvider ownerProvider)
        {
            _statusProvider = statusProvider;
            _commentProvider = commentProvider;
            _customerProvider = customerProvider;
            _actionOptionsProvider = actionOptionsProvider;
            _personnelProvider = personnelProvider;
            _companyProvider = companyProvider;
            _ownerProvider = ownerProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AssignToStorage() // depoya ata
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignToStorage(AssignToStorageDTO storageDto) // depoya ata
        {
            // AddAssetStatus
            
            var addValue = await _statusProvider.AddAssetStatusAsync(storageDto);

            return View();
        }

        [HttpGet]
        public IActionResult TakeOn() // ustlen
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult TakeOn() // ustlen
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> ToConsume() // tüket
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ToConsume(AssetToReturnDTO consumeDTO) // tüket
        {
            // AddCustomer
            // GetCustomer

            var getValue = await _customerProvider.GetAsync();

            var addValue = await _customerProvider.AddToConsumeAsync(consumeDTO);


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AssetToReturn() // Iadet et
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssetToReturn(AssetToReturnDTO toReturnDto) // Iadet et
        {
            // AddCustomer
            // AddAsssetStatus

            var addValueCustomer = await _customerProvider.AddToConsumeAsync(toReturnDto);

            var addValue = await _statusProvider.AddAssetStatusAsync(toReturnDto);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Abort() // iptal et 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Abort(AssetStatusDTO abortDto) // iptal et 
        {
            // AddAsssetStatus
            // GetAssetOption

            var getValue = await _actionOptionsProvider.GetActionOptionAsync();

            var addValue = await _statusProvider.AddAssetStatusAsync(abortDto);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Superannuate() // emekli et
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Superannuate(SuperannuateDTO superannuatedto) // emekli et
        {
            // AddAssetStatus
            // GetActionOption

            var getValue = await _actionOptionsProvider.GetActionOptionAsync();

            var addValue = await _statusProvider.AddAssetStatusAsync(superannuatedto);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LossStolen() // kayip/calinti bildir
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LossStolen(AssetStatusDTO statusDto) // kayip/calinti bildir
        {
            // addAssetStatus

            var addValue = await _statusProvider.AddAssetStatusAsync(statusDto);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Debit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Debit(DebitDTO debitDto) // zimmet ata
        {
            // AddAssetOwner
            // GetAssetOwner
            // GetActionOption
            // AddAssetStatus

            var getOwner = await _ownerProvider.GetAssetOwnerAsync();

            var getOption = await _actionOptionsProvider.GetActionOptionAsync();

            var addOwner = await _ownerProvider.AddAssetOwnerAsync(debitDto);

            var addValue = await _statusProvider.AddAssetStatusAsync(debitDto);

            return View();
        }

        [HttpGet]
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
