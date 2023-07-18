using HotelProject.BuninessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialServices _testimonialServices;

        public TestimonialController(ITestimonialServices testimonialServices)
        {
            _testimonialServices = testimonialServices;
        }

        [HttpGet]
        public IActionResult Testimoniallist()
        {
            var value = _testimonialServices.TGetList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialServices.TInsert(testimonial);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialServices.TGetByID(id);
            _testimonialServices.TDelete(value);
            return Ok();
        }
        [HttpGet("id")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialServices.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialServices.TUpdate(testimonial);
            return Ok();
        }
    }
}
