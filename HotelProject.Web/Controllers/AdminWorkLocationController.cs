using HotelProject.Web.DTOS.RoomDtos;
using HotelProject.Web.DTOS.WorkLocation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.Web.Controllers
{
    public class AdminWorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminWorkLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/WorkLocation");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWorkLocationDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateWorkLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync($"https://localhost:44375/api/WorkLocation/id?id={id}");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultWorkLocationDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWorkLocation(ResultWorkLocationDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsmessage = await client.PutAsync("https://localhost:44375/api/WorkLocation/", stringContent);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddWorkLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(CreateWorkLocation model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsmessage = await client.PostAsync("https://localhost:44375/api/WorkLocation", content);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.DeleteAsync("https://localhost:44375/api/WorkLocation?id=" + id);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
