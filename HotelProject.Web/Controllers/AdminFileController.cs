using Microsoft.AspNetCore.Mvc;
//using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;

namespace HotelProject.Web.Controllers
{
    public class AdminFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        { 
            var stream= new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes=stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType= new MediaTypeHeaderValue(file.ContentType);

            MultipartFormDataContent multipartFormDataContent= new MultipartFormDataContent();

            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var client= new HttpClient();
            var responsmessage = await client.PostAsync("http://localhost:44375/api/FileImage/",multipartFormDataContent);
            if(responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","AdminDashboard");

            }
            return View();

        }
    }
}
