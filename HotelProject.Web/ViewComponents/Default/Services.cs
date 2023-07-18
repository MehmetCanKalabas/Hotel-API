using HotelProject.Web.DTOS.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.Default
{
    public class Services: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Services(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Service");
            if(responsmessage.IsSuccessStatusCode) 
            { 
                var jsonData= await responsmessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
