using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using System.Security.Cryptography;
using JWTAuthentication.DTOs;
using JWTAuthentication.Services;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {        
        private IConfiguration _config;
        private readonly IUserService _userService;


        public UserController(IConfiguration config, IUserService userService)
        {
            _userService = userService;
            _config = config;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResource resource, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _userService.Register(resource, cancellationToken);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { ErrorMessage = e.Message });
            }
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResource resource, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _userService.Login(resource, cancellationToken,_config);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { ErrorMessage = e.Message });
            }
        }

    }
}
