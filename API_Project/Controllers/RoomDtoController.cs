using AutoMapper;
using HotelProject.BuninessLayer.Abstract;
using HotelProject.DTOLayer.DTOS.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomDtoController : ControllerBase
    {
        private readonly IRoomServices _roomServices;
        private readonly IMapper _mapper;

        public RoomDtoController(IRoomServices roomServices, IMapper mapper)
        {
            _roomServices = roomServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = _roomServices.TGetList();
            return Ok(value);

        }

        [HttpPost]
        public IActionResult AddRoom(AddRoomDto roomDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(roomDto);
           _roomServices.TInsert(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var value = _mapper.Map<Room>(updateRoom);
            _roomServices.TUpdate(value);   
            return Ok();
        }
    }
}
