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
        IMapper _mapper;

        public AssetActionController(IAssetActionDAL assetActionDal, IMapper mapper)
        {
            _assetActionDAL = assetActionDal;
            _mapper = mapper;
        }

        [HttpGet("getassetaction")]
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
    }
}
