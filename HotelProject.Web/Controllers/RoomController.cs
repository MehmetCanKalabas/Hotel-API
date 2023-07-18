using HotelProject.Web.DTOS.RoomDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.Controllers
{
    [AllowAnonymous]
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client= _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Room");
            if(responsmessage.IsSuccessStatusCode)
            {
                var jsonData= await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
