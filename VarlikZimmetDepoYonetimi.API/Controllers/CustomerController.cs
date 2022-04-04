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
    public class CustomerController : ControllerBase
    {
        ICustomerDAL _customerDal;
        IMapper _mapper;

        public CustomerController(ICustomerDAL customerDAL, IMapper mapper)
        {
            _customerDal = customerDAL;
            _mapper = mapper;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var value = await _customerDal.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDTO>>(value));
        }

        [HttpPost]
        [Route("~/api/addcustomer")]
        public async Task<IActionResult> ADDAsync([FromBody] CustomerDTO customerDto)
        {
            try
            {
                await _customerDal.AddAsync(_mapper.Map<Customer>(customerDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }       

    }
}
