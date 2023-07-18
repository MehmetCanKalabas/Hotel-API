using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.Default
{
    public class Navbar: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
