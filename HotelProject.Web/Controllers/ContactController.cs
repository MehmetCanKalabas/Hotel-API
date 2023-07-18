using HotelProject.Web.DTOS.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.Web.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.Date= Convert.ToDateTime(DateTime.Now.ToString());
            var client= _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(createContactDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responsmessage = await client.PostAsync("https://localhost:44375/api/Contact", content);
            if(responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }

       
    }
}
