using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.DTOS.Login_Dtos
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Kullanıcı Adınızı Giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifrenizi Giriniz")]
        public string Password { get; set; }
    }
}
