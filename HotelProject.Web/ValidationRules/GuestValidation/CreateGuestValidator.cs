using FluentValidation;
using HotelProject.Web.DTOS.GuestDtos;

namespace HotelProject.Web.ValidationRules.GuestValidation
{
    public class CreateGuestValidator:AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Mail Bilginizi Giriniz");
            RuleFor(x => x.Room).NotEmpty().WithMessage("Oda Bilgisi Giriniz");
        }
    }
}
