using _53_Jwt.Models;
using _53_Jwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _53_Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        public AuthController(JwtService jwtService)
        {
            _jwtService=jwtService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            if(loginRequest.UserName=="berkant" && loginRequest.Password == "12345")
            {
                var token = _jwtService.GenerateToken("1", loginRequest.UserName);
                return Ok(new {token});
            }

            return Unauthorized("Kullanıcı adı veya şifre hatalı"); 
        }
    }
}
