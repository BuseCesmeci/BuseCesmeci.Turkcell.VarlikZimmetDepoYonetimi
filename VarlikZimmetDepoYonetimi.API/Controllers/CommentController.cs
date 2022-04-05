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
    public class CommentController : ControllerBase
    {
        ICommentDAL _commentDal;
        IMapper _mapper;

        public CommentController(ICommentDAL commentDAL, IMapper mapper)
        {
            _commentDal = commentDAL;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("~/api/addcomment")]
        public async Task<IActionResult> AddCommentAsync([FromBody] CommentDTO commentDto)
        {
            try
            {
                await _commentDal.AddAsync(_mapper.Map<Comment>(commentDto));
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
            }
            return BadRequest();
        }
    }
}
