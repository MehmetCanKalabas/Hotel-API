using HotelProject.DataAccessLayer.Concrete;
using HotelProject.Web.DTOS.StaffDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            using var context= new Context();
            ViewBag.guest = context.Guests.Count();
            ViewBag.staff=context.Staff.Count();
            ViewBag.room=context.Rooms.Count();
            ViewBag.services=context.Services.Count();
            return View();
        }

        
    }
}
