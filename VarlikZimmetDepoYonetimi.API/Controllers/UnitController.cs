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
    public class UnitController : ControllerBase
    {
        IUnitDAL _unitDal;
        IMapper _mapper;

        public UnitController(IUnitDAL unitDAL, IMapper mapper )
        {
            _unitDal = unitDAL;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUnitAsync()
        {
            var value = await _unitDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<UnitDTO>>(value));
        }

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

    }
}
