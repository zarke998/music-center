using Microsoft.AspNetCore.Mvc;
using MusicCenter.API.Core;
using MusicCenter.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtManager _jwtManager;

        public LoginController(JwtManager jwtManager)
        {
            this._jwtManager = jwtManager;
        }

        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            var token = _jwtManager.MakeToken(request.Email, request.Password);

            if (token == null)
            {
                return NotFound("No user found. Check your email and password.");
            }

            return Ok(new { token });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
