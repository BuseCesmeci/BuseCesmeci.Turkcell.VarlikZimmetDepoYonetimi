using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.DTOs;
using VarlikZimmetDepoYonetimi.Core.Models.Entities;
using VarlikZimmetDepoYonetimi.Data.DAL;

namespace VarlikZimmetDepoYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetActionController : ControllerBase
    {
        IAssetActionDAL _assetActionDAL;
        IAssetStatusDAL _assetStatusDal;
        IAssetOwnerDAL _assetOwnerDal;
        IAssetActionOptionsDAL _actionoptionDal;
        ICompanyDAL _companyDal;
        IAssetCustomerDAL _assetCustomerDal;
        ICustomerDAL _customerDal;
        ICommentDAL _commentDal;
        IMapper _mapper;

        public AssetActionController(IAssetActionDAL assetActionDal, IAssetStatusDAL assetStatusDal, IAssetOwnerDAL assetOwnerDal, IAssetActionOptionsDAL actionoptionDal,
           ICompanyDAL companyDal, IAssetCustomerDAL assetCustomerDal, ICustomerDAL customerDal, ICommentDAL commentDal, IMapper mapper)
        {
            _assetActionDAL = assetActionDal;
            _assetStatusDal = assetStatusDal;
            _assetOwnerDal = assetOwnerDal;
            _actionoptionDal = actionoptionDal;
            _assetCustomerDal = assetCustomerDal;
            _customerDal = customerDal;
            _commentDal = commentDal;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var value = await _assetActionDAL.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AssetActionDTO>>(value));
        }

        [HttpGet("{assetActionID}")]
        public async Task<IActionResult> GETAsync(int assetActionID)
        {
            try
            {
                AssetActionDTO assetActionDto = _mapper.Map<AssetActionDTO>(await _assetActionDAL.GetAsync(x => x.AssetActionID == assetActionID));

                if (assetActionDto == null)
                {
                    return NotFound($"{assetActionID} e ait veri bulunamadı..");
                }
                else
                {
                    return Ok(assetActionDto);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpPost]
        //[Route("~/api/addassetaction")]
        //public async Task<IActionResult> ADDAsync([FromBody] AssetActionDTO assetActionDto)
        //{
        //    try
        //    {
        //        await _assetActionDAL.AddAsync(_mapper.Map<AssetAction>(assetActionDto));
        //        return new StatusCodeResult(201);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        [HttpPost]
        [Route("~/api/addassetaction")]
        public IActionResult ADD([FromBody] AssetActionDTO assetActionDto)
        {
            try
            {
                _assetActionDAL.Add(_mapper.Map<AssetAction>(assetActionDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPut]
        [Route("~/api/updateassetaction")]
        public async Task<IActionResult> UPDATEAsync([FromBody] AssetActionDTO assetActionDto)
        {
            try
            {
                await _assetActionDAL.UpdateAsync(_mapper.Map<AssetAction>(assetActionDto));
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("assetActionID")]
        public async Task<IActionResult> DELETEAsync(int assetActionID)
        {
            try
            {
                await _assetActionDAL.DeleteAsync(_mapper.Map<AssetAction>(new AssetActionDTO() { AssetActionID = assetActionID }));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("~/api/addassetstatus")]
        public async Task<IActionResult> AddAssetStatusAsync([FromBody] AssetStatusDTO assetStatusDto)
        {
            try
            {
                await _assetStatusDal.AddAsync(_mapper.Map<AssetStatus>(assetStatusDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }

        // ZİMMET ATA tbl.assetstatus , tbl.assetowner, get-- tbl.assetActionOption        

        [HttpPost]
        [Route("~/api/addassetowner")]
        public async Task<IActionResult> AddAssetOwnerAsync([FromBody] AssetOwnerDTO assetOwnerDto)
        {
            try
            {
                await _assetOwnerDal.AddAsync(_mapper.Map<AssetOwner>(assetOwnerDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAssetActionOptionAsync()
        {
            var value = await _actionoptionDal.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AssetActionOptionsDTO>>(value));
        }

        // DEPOYA ATA tbl.assetstatus, get-- tbl.company

        [HttpGet("")]
        public async Task<IActionResult> GetCompanyAsync()
        {
            var value = await _companyDal.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(value));
        }


        // TÜKET    tbl.assetstatus, tbl.assetcustomer, get-- tbl.customer

        [HttpGet("")]
        public async Task<IActionResult> GetCustomerAsync()
        {
            var value = await _customerDal.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDTO>>(value));
        }

        [HttpPost]
        [Route("~/api/addassetcustomer")]
        public async Task<IActionResult> AddAssetCustomerAsync([FromBody] AssetCustomerDTO assetCustomerDto)
        {
            try
            {
                await _assetCustomerDal.AddAsync(_mapper.Map<AssetCustomer>(assetCustomerDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }

        // İADE ET  tbl.assetstatus, tbl.assetcustomer

        //  EMEKLİ ET    tbl.assetstatus,

        // KAYIP/ÇALINTI    tbl.assetststus

        //  YORUM EKLE  tbl.comment

        [HttpPost]
        [Route("~/api/addcomment")]
        public async Task<IActionResult> AddCommentAsync([FromBody] CommentDTO commentDto)
        {
            try
            {
                await _commentDal.AddAsync(_mapper.Map<Comment>(commentDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }
    }
}
