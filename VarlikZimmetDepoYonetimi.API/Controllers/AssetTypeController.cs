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
    public class AssetTypeController : ControllerBase
    {
        IAssetTypeDAL _assetTypeDal;
        IMapper _mapper;

        public AssetTypeController(IAssetTypeDAL assetTypeDal, IMapper mapper)
        {
            _assetTypeDal = assetTypeDal;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var value = await _assetTypeDal.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AssetTypeDTO>>(value));
        }

        [HttpPost]
        [Route("~/api/addassettype")]
        public async Task<IActionResult> ADDAsync([FromBody] AssetTypeDTO assetTypeDto)
        {
            try
            {
                await _assetTypeDal.AddAsync(_mapper.Map<AssetType>(assetTypeDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }

    }
}
