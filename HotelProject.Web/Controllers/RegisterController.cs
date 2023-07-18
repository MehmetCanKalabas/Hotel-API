using HotelProject.EntityLayer.Concrete;
using HotelProject.Web.DTOS.RegisterDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createNewUserDto.Name,
                Email = createNewUserDto.Email,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.Username,
                ImageUrl = createNewUserDto.ImageUrl,
                Department = createNewUserDto.Department,
                Status="Aktif",
                City=createNewUserDto.City
            };
            var result= await _userManager.CreateAsync(appUser, createNewUserDto.Password);
            if(result.Succeeded)
            {
                
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
