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
    public class AssetPriceController : ControllerBase
    {
        IPriceDAL _priceDal;
        IMapper _mapper;

        public AssetPriceController(IPriceDAL priceDAL, IMapper mapper)
        {
            _priceDal = priceDAL;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAssetPriceAsync()
        {
            var value = await _priceDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<PriceDTO>>(value));
        }

        [HttpPost]
        [Route("~/api/addassetprice")]
        public async Task<IActionResult> AddAssetPriceAsync([FromBody] PriceDTO priceDto)
        {
            try
            {
                await _priceDal.AddAsync(_mapper.Map<Price>(priceDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }
        
        [HttpPut]
        [Route("~/api/updateassetprice")]
        public async Task<IActionResult> UpdateAssetPriceAsync([FromBody] PriceDTO priceDto)
        {
            try
            {
                await _priceDal.UpdateAsync(_mapper.Map<Price>(priceDto));
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
