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
    public class AssetGroupController : ControllerBase
    {
        IAssetGroupDAL _assetGroupDal;
        IMapper _mapper;

        public AssetGroupController(IAssetGroupDAL assetGroupDAL, IMapper mapper)
        {
            _assetGroupDal = assetGroupDAL;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAssetGroupAsync()
        {
            var value = await _assetGroupDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetGroupDTO>>(value));
        }

        [HttpPost]
        [Route("~/api/addassetgroup")]
        public async Task<IActionResult> ADDAsync([FromBody] AssetGroupDTO assetGroupDto)
        {
            try
            {
                await _assetGroupDal.AddAsync(_mapper.Map<AssetGroup>(assetGroupDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }
    }
}
