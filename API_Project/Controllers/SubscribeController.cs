using HotelProject.BuninessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeServices _subscribeServices;

        public SubscribeController(ISubscribeServices subscribeServices)
        {
            _subscribeServices = subscribeServices;
        }

        [HttpGet]
        public IActionResult Subscribelist()
        {
            var value = _subscribeServices.TGetList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            _subscribeServices.TInsert(subscribe);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var value = _subscribeServices.TGetByID(id);
            _subscribeServices.TDelete(value);
            return Ok();
        }
        [HttpGet("id")]
        public IActionResult GetSubscribe(int id)
        {
            var values = _subscribeServices.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _subscribeServices.TUpdate(subscribe);
            return Ok();
        }
    }
}
