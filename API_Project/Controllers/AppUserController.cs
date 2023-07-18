using HotelProject.BuninessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserServices _appUserServices;

        public AppUserController(IAppUserServices appUserServices)
        {
            _appUserServices = appUserServices;
        }

        [HttpGet]
        public IActionResult AppUserlist()
        {
            var value = _appUserServices.TUserListWithLocation();
            return Ok(value);
        }
    }
}
