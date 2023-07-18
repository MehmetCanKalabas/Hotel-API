using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.AdminDashboard
{
    public class FaceBookFollowers: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
