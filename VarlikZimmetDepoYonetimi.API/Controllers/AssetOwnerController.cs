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
    public class AssetOwnerController : ControllerBase
    {
        IAssetOwnerDAL _assetOwnerDal;
        IAssetActionOptionsDAL _actionoptionDal;
        IMapper _mapper;

        public AssetOwnerController(IAssetOwnerDAL assetOwnerDAL, IAssetActionOptionsDAL assetActionOptionsDAL, IMapper mapper)
        {
            _assetOwnerDal = assetOwnerDAL;
            _actionoptionDal = assetActionOptionsDAL ;
            _mapper = mapper;
        }

        // ZİMMET ATA tbl.assetstatus , tbl.assetowner, get-- tbl.assetActionOption        

        [HttpGet("")]
        public async Task<IActionResult> GetAssetOwnerAsync()
        {
            var value = await _assetOwnerDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetOwnerDTO>>(value));
        }


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

        [HttpGet("getassetactionoption")]
        public async Task<IActionResult> GetAssetActionOptionAsync()
        {
            var value = await _actionoptionDal.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AssetActionOptionsDTO>>(value));
        }

    }
}
