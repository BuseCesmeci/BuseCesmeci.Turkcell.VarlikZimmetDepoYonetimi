using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.DTOs;
using VarlikZimmetDepoYonetimi.Data.DAL;

namespace VarlikZimmetDepoYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerTypeController : ControllerBase
    {
        IOwnerTypeDAL _ownerTypeDal;
        IMapper _mapper;

        public OwnerTypeController(IOwnerTypeDAL ownerTypeDAL, IMapper mapper)
        {
            _ownerTypeDal = ownerTypeDAL;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var value = await _ownerTypeDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<OwnerTypeDTO>>(value));
        }
    }
}
