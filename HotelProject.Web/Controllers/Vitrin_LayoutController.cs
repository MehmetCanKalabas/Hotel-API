using HotelProject.Web.DTOS.SubscribeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.Web.Controllers
{
    public class Vitrin_LayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Vitrin_LayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
