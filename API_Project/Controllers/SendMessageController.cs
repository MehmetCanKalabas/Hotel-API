using HotelProject.BuninessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageServices _sendMessageServices;

        public SendMessageController(ISendMessageServices sendMessageServices)
        {
            _sendMessageServices = sendMessageServices;
        }

        [HttpGet]
        public IActionResult SendMessagelist()
        {
            var value = _sendMessageServices.TGetList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendMessageServices.TInsert(sendMessage);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteSendMessage(int id)
        {
            var value = _sendMessageServices.TGetByID(id);
            _sendMessageServices.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessahe(int id)
        {
            var values = _sendMessageServices.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageServices.TUpdate(sendMessage);
            return Ok();
        }
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            return Ok(_sendMessageServices.TGetSendMessageCount());
        }
    }
}
