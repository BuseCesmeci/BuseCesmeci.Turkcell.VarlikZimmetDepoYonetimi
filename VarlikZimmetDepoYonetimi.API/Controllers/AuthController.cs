using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.DTOs;
using VarlikZimmetDepoYonetimi.Core.IRepositories;
using VarlikZimmetDepoYonetimi.Core.Models.Entities;

namespace VarlikZimmetDepoYonetimi.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthRepository _authRepository;
        IConfiguration  _configuration;
        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (await _authRepository.UserExist(dto.Username))
            {
                ModelState.AddModelError("error username notvalid", "kullanıcı zaten mevcut");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var user = new LoginInfo() { Username = dto.Username };

            await _authRepository.Register(user, dto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var user = await _authRepository.Login(dto.Username, dto.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

                var description = new SecurityTokenDescriptor()
                {
                    Expires = DateTime.Now.AddDays(1),
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.LoginInfoID.ToString()),
                        new Claim(ClaimTypes.Name, user.Username)
                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)

                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(description);
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(tokenString);
            }
        }
    }
}
