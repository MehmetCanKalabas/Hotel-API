using HotelProject.Web.DTOS.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.Default
{
    public class About: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public About(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/About");
            if(responsmessage.IsSuccessStatusCode)
            {
                var jsonData= await responsmessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
