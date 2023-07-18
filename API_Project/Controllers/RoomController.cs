using HotelProject.BuninessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomServices _roomServices;

        public RoomController(IRoomServices roomServices)
        {
            _roomServices = roomServices;
        }

        [HttpGet]
        public IActionResult Roomlist()
        {
            var value=_roomServices.TGetList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            _roomServices.TInsert(room);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var value=_roomServices.TGetByID(id);
            _roomServices.TDelete(value);
            return Ok();
        }
        [HttpGet("id")]
        public IActionResult GetRoom(int id)
        {
            var value=_roomServices.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomServices.TUpdate(room);
            return Ok();
        }
    }
}
