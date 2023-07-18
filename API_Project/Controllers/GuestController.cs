using HotelProject.BuninessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestServices _guestServices;

        public GuestController(IGuestServices guestServices)
        {
            _guestServices = guestServices;
        }

        [HttpGet]
        public IActionResult Guestlist()
        {
            var value = _guestServices.TGetList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            _guestServices.TInsert(guest);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGuest(int id)
        {
            var value = _guestServices.TGetByID(id);
            _guestServices.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var values = _guestServices.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            _guestServices.TUpdate(guest);
            return Ok();
        }
    }
}
