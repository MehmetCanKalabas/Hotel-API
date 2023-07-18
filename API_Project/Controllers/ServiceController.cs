using HotelProject.BuninessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceServices _serviceServices;

        public ServiceController(IServiceServices serviceServices)
        {
            _serviceServices = serviceServices;
        }

        [HttpGet]
        public IActionResult Servicelist()
        {
            var value = _serviceServices.TGetList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceServices.TInsert(service);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _serviceServices.TGetByID(id);
            _serviceServices.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var values = _serviceServices.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _serviceServices.TUpdate(service);
            return Ok();
        }
    }
}
