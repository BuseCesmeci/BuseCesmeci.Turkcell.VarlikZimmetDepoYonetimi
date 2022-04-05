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
    public class BrandModelController : ControllerBase
    {
        IBrandModelDAL _brandModelDal;
        IMapper _mapper;

        public BrandModelController(IBrandModelDAL brandModelDAL, IMapper mapper)
        {
            _brandModelDal = brandModelDAL;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var value = await _brandModelDal.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BrandModelDTO>>(value));
        }

        [HttpGet("{brandmodelID}")]
        public async Task<IActionResult> GetByIdAsync(int brandmodelID)
        {
            try
            {
                var brandmodel = await _brandModelDal.GetByIdAsync(brandmodelID);
                var brandmodelDto = _mapper.Map<BrandModelDTO>(brandmodel);
                return Ok(brandmodelDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("~/api/addbrandmodel")]
        public async Task<IActionResult> ADDAsync([FromBody] BrandModelDTO brandmodelDto)
        {
            try
            {
                await _brandModelDal.AddAsync(_mapper.Map<BrandModel>(brandmodelDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("~/api/updatebrandmodel")]
        public async Task<IActionResult> UPDATEAsync([FromBody] BrandModelDTO brandmodelDto)
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

        [HttpPost("brandmodelID")]
        public async Task<IActionResult> SOFTDeleteAsync(int brandmodelID)
        {
            try
            {           // bakılacak yanlış

                await _brandModelDal.UpdateAsync(_mapper.Map<BrandModel>(brandmodelID));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
