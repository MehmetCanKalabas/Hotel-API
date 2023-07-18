using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.DTOS.ServiceDtos
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Hizmet ikon linki giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage ="Hizmet başlığı giriniz")]
        public string ServiceTitle { get; set; }

        public string Description { get; set; }
    }
}
