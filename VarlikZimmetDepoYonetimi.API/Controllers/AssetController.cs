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
        IAssetBarcodeDAL _assetBarcodeDal;
        IAssetStatusDAL _assetStatusDal;
        IPriceDAL _priceDal;
        IUnitDAL _unitDal;
        IAssetTypeDAL _assetTypeDal;
        IAssetGroupDAL _assetGroupDal;
        IBrandModelDAL _brandModelDal;
        IMapper _mapper;

        public AssetController(IMapper mapper,IAssetDAL assetDal, IAssetBarcodeDAL assetBarcodeDal, IAssetStatusDAL assetStatusDal, IPriceDAL priceDal, IUnitDAL unitDal, 
            IAssetTypeDAL assetTypeDal, IAssetGroupDAL assetGroupDal, IBrandModelDAL brandModelDal)
        {
            _mapper = mapper;
            _assetDal = assetDal;
            _assetBarcodeDal = assetBarcodeDal;
            _assetStatusDal = assetStatusDal;
            _unitDal = unitDal;
            _priceDal = priceDal;
            _assetTypeDal = assetTypeDal;
            _assetGroupDal = assetGroupDal;
            _brandModelDal = brandModelDal;
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
                //var assetDto = await _mapper.Map<Asset>( _assetDal.GetByIdAsync(x => x.AssetID == assetID));
                //if (assetDto == null)
                //{
                //   return NotFound($"{assetID} e ait veri bulunamadı..");
                //}
                //else
                //{
                //    return Ok(assetDto);
                //}
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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


        // BARCODE
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

        [HttpGet("")]
        public async Task<IActionResult> GetAssetBarcodeAsync()
        {
            var value = await _assetBarcodeDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetBarcodeDTO>>(value));
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


        // ASSET STATUS
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

        [HttpGet("")]
        public async Task<IActionResult> GetAssetStatusAsync()
        {
            var value = await _assetStatusDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetStatusDTO>>(value));
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

        //PRICE
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


        [HttpGet("")]
        public async Task<IActionResult> GetAssetPriceAsync()
        {
            var value = await _priceDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<PriceDTO>>(value));
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


        // UNIT
        [HttpPost]
        [Route("~/api/addassetunit")]
        public async Task<IActionResult> AddAssetUnitAsync([FromBody] UnitDTO unitDto)
        {
            try
            {
                await _unitDal.AddAsync(_mapper.Map<Unit>(unitDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUnitAsync()
        {
            var value = await _unitDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<UnitDTO>>(value));
        }

        // ASSETTYPE - GET
        [HttpGet("")]
        public async Task<IActionResult> GetAssetTypeAsync()
        {
            var value = await _assetTypeDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetTypeDTO>>(value));
        }

        [HttpPut]
        [Route("~/api/updateassettype")]
        public async Task<IActionResult> UpdateAssetTypeAsync([FromBody] AssetTypeDTO assetTypeDto)
        {
            try
            {
                await _assetTypeDal.UpdateAsync(_mapper.Map<AssetType>(assetTypeDto));
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // ASSETGROUP - GET
        [HttpGet("")]
        public async Task<IActionResult> GetAssetGroupAsync()
        {
            var value = await _assetGroupDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetGroupDTO>>(value));
        }

        // BRAND - GET
        [HttpGet("")]
        public async Task<IActionResult> GetBrandAsync()
        {
            var value = await _brandModelDal.GetAllAsync(x=>x.isActive == true && x.UpperBrandModelMi == true);
            return Ok(_mapper.Map<IEnumerable<BrandModelDTO>>(value));
        }

        [HttpPut]
        [Route("~/api/updatebrandmodel")]
        public async Task<IActionResult> UpdateBrandModelAsync([FromBody] BrandModelDTO brandmodelDto)
        {
            try
            {
                await _brandModelDal.UpdateAsync(_mapper.Map<BrandModel>(brandmodelDto));
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // MODEL - GET
        [HttpGet("")]
        public async Task<IActionResult> GetModelAsync()
        {
            var value = await _brandModelDal.GetAllAsync(x => x.isActive == true && x.UpperBrandModelMi == false);
            return Ok(_mapper.Map<IEnumerable<BrandModelDTO>>(value));
        }


    }
}
