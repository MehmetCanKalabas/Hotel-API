using HotelProject.Web.DTOS.Contact;
using HotelProject.Web.DTOS.Contact.SendMessage;
using HotelProject.Web.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.Web.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Contact");

            var client2= _httpClientFactory.CreateClient();
            var responsmessage2 = await client2.GetAsync("https://localhost:44375/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responsmessage3 = await client3.GetAsync("https://localhost:44375/api/SendMessage/GetSendMessageCount");

            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                var jsonData2= await responsmessage2.Content.ReadAsStringAsync();
                var jsonData3 = await responsmessage3.Content.ReadAsStringAsync();
                ViewBag.sendCount = jsonData3;
                ViewBag.contactCount = jsonData2;

                return View(value);
            }
            return View();
        }
     
        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderMail = "gizem@gmail.com";
            model.SenderName = "Admin";
            model.Date= DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsmessage = await client.PostAsync("https://localhost:44375/api/SendMessage", content);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/SendMessage");

            
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSendMessage>>(jsonData);
                
                return View(value);
            }
            return View();
        }
        public async Task<IActionResult> ReadMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync($"https://localhost:44375/api/Contact/{id}");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(value);
            }
            return View();
        }
        public async Task<IActionResult> ReadMessageSend(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync($"https://localhost:44375/api/SendMessage/{id}");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultSendMessage>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
