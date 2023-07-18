using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.DTOS.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage ="Kizmet ikon linki giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage ="Hizmet başlığı giriniz")]
        public string ServiceTitle { get; set; }
        public string Description { get; set; }
    }
}
