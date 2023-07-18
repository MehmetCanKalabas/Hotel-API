using HotelProject.Web.DTOS.BookingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace HotelProject.Web.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Onay Bekliyor";
            var client= _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8 ,"application/json");
           var responsmessage= await client.PostAsync("https://localhost:44375/api/Booking",content);
            if(responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");

            }
            return View();

        }

    }

}
