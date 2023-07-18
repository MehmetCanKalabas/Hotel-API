using HotelProject.BuninessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffServices _staffServices;

        public StaffController(IStaffServices staffServices)
        {
            _staffServices = staffServices;
        }

        [HttpGet]
        public IActionResult Stafflist()
        {
            var value= _staffServices.TGetList();
            return Ok(value);
        }
    
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffServices.TInsert(staff);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            var value= _staffServices.TGetByID(id);
            _staffServices.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var values=_staffServices.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffServices.TUpdate(staff);
            return Ok();
        }
    }
}
