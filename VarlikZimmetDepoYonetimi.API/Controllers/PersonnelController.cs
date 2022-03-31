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
    public class PersonnelController : ControllerBase
    {
        IPersonnelDAL _personnelDAL;
        IMapper _mapper;

        public PersonnelController(IPersonnelDAL personnelDAL, IMapper mapper)
        {
            _personnelDAL = personnelDAL;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var value = await _personnelDAL.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonnelDTO>>(value));
        }


        [HttpGet("{personelID}")]
        public async Task<IActionResult> GETAsync(int personelID)
        {
            try
            {
                PersonnelDTO personnelDto = _mapper.Map<PersonnelDTO>(await _personnelDAL.GetAsync(x => x.PersonnelID == personelID));

                if (personnelDto == null)
                {
                    return NotFound($"{personelID} e ait veri bulunamadı..");
                }
                else
                {
                    return Ok(personnelDto);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("~/api/addpersonnel")]
        public async Task<IActionResult> ADDAsync([FromBody] PersonnelDTO personnelDto)
        {
            try
            {
                await _personnelDAL.AddAsync(_mapper.Map<Personnel>(personnelDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("~/api/updatepersonnel")]
        public async Task<IActionResult> UPDATEAsync([FromBody] PersonnelDTO personnelDto)
        {
            try
            {
                await _personnelDAL.UpdateAsync(_mapper.Map<Personnel>(personnelDto));
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("personnelID")]
        public async Task<IActionResult> DELETEAsync(int personnelID)
        {
            try
            {
                await _personnelDAL.DeleteAsync(_mapper.Map<Personnel>(new PersonnelDTO() { PersonnelID = personnelID }));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
