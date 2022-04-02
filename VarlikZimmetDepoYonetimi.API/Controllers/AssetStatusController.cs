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
    public class AssetStatusController : ControllerBase
    {
        IAssetStatusDAL _assetStatusDal;
        IMapper _mapper;

        public AssetStatusController(IAssetStatusDAL assetStatusDAL, IMapper mapper )
        {
            _assetStatusDal = assetStatusDAL;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAssetStatusAsync()
        {
            var value = await _assetStatusDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetStatusDTO>>(value));
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

       
        [HttpPut]
        [Route("~/api/updateassetstatus")]
        public async Task<IActionResult> UpdateAssetStatusAsync([FromBody] AssetStatusDTO assetStatusDto)
        {
            try
            {
                await _assetStatusDal.UpdateAsync(_mapper.Map<AssetStatus>(assetStatusDto));
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
