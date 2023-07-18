using HotelProject.DTOLayer.DTOS.RoomDto;
using HotelProject.Web.DTOS.AboutDtos;
using HotelProject.Web.DTOS.RoomDtos;
using HotelProject.Web.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.Web.Controllers
{
    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminRoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Room");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync($"https://localhost:44375/api/Room/id?id={id}");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultRoomDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(ResultRoomDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsmessage = await client.PutAsync("https://localhost:44375/api/Room/", stringContent);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsmessage = await client.PostAsync("https://localhost:44375/api/Room", content);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.DeleteAsync("https://localhost:44375/api/Room?id=" + id);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
