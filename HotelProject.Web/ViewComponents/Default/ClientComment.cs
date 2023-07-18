using HotelProject.Web.DTOS.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.Default
{
    public class ClientComment: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientComment(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Testimonial");
            if(responsmessage.IsSuccessStatusCode)
            {
                var jsonData= await responsmessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
