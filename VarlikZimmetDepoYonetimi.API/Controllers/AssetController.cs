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
    public class AssetController : ControllerBase
    {
        IAssetDAL _assetDal;
        IMapper _mapper;

        public AssetController(IMapper mapper,IAssetDAL assetDal)
        {
            _mapper = mapper;
            _assetDal = assetDal;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var value = await _assetDal.GetAllAsync(x=>x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetDTO>>(value));
        }

        [HttpGet("{assetID}")]
        public async Task<IActionResult> GetByIdAsync(int assetID)
        {
            try
            {

                var asset = await _assetDal.GetByIdAsync(assetID);
                var assetDto = _mapper.Map<AssetDTO>(asset);

                return Ok(assetDto);
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }            
        }

        [HttpPost]
        [Route("~/api/addasset")]
        public async Task<IActionResult> ADDAsync([FromBody] AssetDTO assetDto)
        {
            try
            {
                await _assetDal.AddAsync(_mapper.Map<Asset>(assetDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {                
            }
            return BadRequest();
        }      


            //[HttpPost]
            //[Route("~/api/addasset")]
            //public IActionResult ADD([FromBody] AssetDTO assetDto)
            //{
            //    try
            //    {
            //        _assetDal.Add(_mapper.Map<Asset>(assetDto));

            //        return new StatusCodeResult(201);
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //    return BadRequest();
            //}


         [HttpPut]
        [Route("~/api/updateasset")]
        public async Task<IActionResult> UPDATEAsync([FromBody] AssetDTO assetDto)
        {
            try
            {
                await _assetDal.UpdateAsync(_mapper.Map<Asset>(assetDto));
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }          
        }

        [HttpPost("assetID")]
        public async Task<IActionResult> SOFTDeleteAsync(int assetID)
        {
            try
            {           // bakılacak yanlış

                await _assetDal.UpdateAsync(_mapper.Map<Asset>(assetID));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("assetID")]
        public async Task<IActionResult> DELETEAsync(int assetID)
        {
            try
            {
                await _assetDal.DeleteAsync(_mapper.Map<Asset>(new AssetDTO() { AssetID = assetID }));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }
    }
}
