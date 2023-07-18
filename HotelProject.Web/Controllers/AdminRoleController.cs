using HotelProject.EntityLayer.Concrete;
using HotelProject.Web.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class AdminRoleController : Controller
    {
        private  readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminRoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var value= _userManager.Users.ToList();
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user= _userManager.Users.FirstOrDefault(x => x.Id==id);
            TempData["userId"] = user.Id;
            var roles= _roleManager.Roles.ToList();
            var userRole = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel model=new RoleAssignViewModel();
                model.RoleID = role.Id;
                model.RoleName = role.Name;
                model.RoleExist = userRole.Contains(role.Name);
                roleAssignViewModels.Add(model);
                
            }
            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModel)
        {
            var userId= (int)TempData["userId"];
            var user= _userManager.Users.FirstOrDefault(x=>x.Id==userId);
            foreach(var item in roleAssignViewModel)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
