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
    public class AssetCustomerController : ControllerBase
    {
        IAssetCustomerDAL _assetCustomerDal;
        ICustomerDAL _customerDAL;
        IMapper _mapper;

        public AssetCustomerController(IAssetCustomerDAL assetCustomerDAL, ICustomerDAL customerDAL, IMapper mapper)
        {
            _assetCustomerDal = assetCustomerDAL;
            _customerDAL = customerDAL;
            _mapper = mapper;
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


        [HttpGet("")]
        public async Task<IActionResult> GetCustomerAsync()
        {
            var value = await _customerDAL.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDTO>>(value));
        }


    }
}
