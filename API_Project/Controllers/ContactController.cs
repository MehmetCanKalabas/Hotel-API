using HotelProject.BuninessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _contactServices;

        public ContactController(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            contact.Date=Convert.ToDateTime(DateTime.Now.ToString());
            _contactServices.TInsert(contact);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
           var value= _contactServices.TGetList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var values = _contactServices.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            return Ok(_contactServices.TGetContactCount());
        }
       

    }
}
