using API_Project.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [HttpGet("[action]")]
        public IActionResult Admin()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult TokenAdmin()
        {
            return Ok("Token Başarılı");
        }
    }
}
