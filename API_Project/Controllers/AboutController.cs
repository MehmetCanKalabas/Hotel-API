using HotelProject.BuninessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutServices;

        public AboutController(IAboutService aboutServices)
        {
            _aboutServices = aboutServices;
        }

        [HttpGet]
        public IActionResult Aboutlist()
        {
            var value = _aboutServices.TGetList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutServices.TInsert(about);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutServices.TGetByID(id);
            _aboutServices.TDelete(value);
            return Ok();
        }
        [HttpGet("id")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutServices.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            _aboutServices.TUpdate(about);
            return Ok();
        }
    }
}
