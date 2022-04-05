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
    public class AssetBarcodeController : ControllerBase
    {
        IAssetBarcodeDAL _assetBarcodeDal;
        IMapper _mapper;

        public AssetBarcodeController(IAssetBarcodeDAL assetBarcodeDAL, IMapper mapper)
        {
            _assetBarcodeDal = assetBarcodeDAL;
            _mapper = mapper;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAssetBarcodeAsync()
        {
            var value = await _assetBarcodeDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetBarcodeDTO>>(value));
        }

        [HttpPost]
        [Route("~/api/addassetbarcode")]
        public async Task<IActionResult> AddAssetBarcodeAsync([FromBody] AssetBarcodeDTO assetBarcodeDto)
        {
            try
            {
                await _assetBarcodeDal.AddAsync(_mapper.Map<AssetBarcode>(assetBarcodeDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }
        

        [HttpPut]
        [Route("~/api/updateassetbarcode")]
        public async Task<IActionResult> UpdateBarcodeAsync([FromBody] AssetBarcodeDTO assetBarcodeDto)
        {
            try
            {
                await _assetBarcodeDal.UpdateAsync(_mapper.Map<AssetBarcode>(assetBarcodeDto));
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
