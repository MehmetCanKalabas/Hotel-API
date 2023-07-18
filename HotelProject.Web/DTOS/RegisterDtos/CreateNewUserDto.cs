using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.DTOS.RegisterDtos
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad girilmesi gereklidir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadı girilmesi gereklidir")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı girilmesi gereklidir")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email girilmesi gereklidir")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Şehir giriniz")]
        public string City { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Şifre girilmesi gereklidir")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Şifreyi tekrar girmelisiniz")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmadı")]
        public string ConfirmPassword { get; set; }
        public string Department { get; set; }
    }
}
