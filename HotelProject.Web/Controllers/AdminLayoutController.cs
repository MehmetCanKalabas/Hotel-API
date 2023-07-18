using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
