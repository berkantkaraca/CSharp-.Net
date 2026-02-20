using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _47_Middleware.Models;

namespace _47_Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("user")]
        public IActionResult GetUser()
        {
            return Ok(new UserDto { Age=30,Email="berkant@gmail.com",Name="berkant"});
        }

        [Authorize]
        [HttpGet("secret")]
        public IActionResult Secret()
        {
            return Ok(new UserDto { Age = 30, Email = "berkant@gmail.com", Name = "berkant" });
        }

        [Authorize(Policy = "HasXHeader")]
        [HttpGet("secure")]
        public IActionResult Secure()
        {
            return Ok(new UserDto { Age = 30, Email = "berkant@gmail.com", Name = "berkant" });
        }
    }
}
