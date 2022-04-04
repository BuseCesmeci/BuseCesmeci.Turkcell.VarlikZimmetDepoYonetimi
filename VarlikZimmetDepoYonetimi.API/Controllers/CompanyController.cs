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
    public class CompanyController : ControllerBase
    {
        ICompanyDAL _companyDal;
        IMapper _mapper;

        public CompanyController(ICompanyDAL companyDAL, IMapper mapper)
        {
            _companyDal = companyDAL;
            _mapper = mapper;
        }

        // DEPOYA ATA tbl.assetstatus, get-- tbl.company

        [HttpGet("")]
        public async Task<IActionResult> GetCompanyAsync()
        {
            var value = await _companyDal.GetAllAsync(x=>x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(value));
        }       

    }
}
