using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DTOLayer.DTOS.RoomDto
{
    public class AddRoomDto
    {
        [Required(ErrorMessage ="Lütfen Oda Numarasını Giriniz")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage ="Lütfen fiyat bilgisi giriniz")]
        public decimal RoomPrice { get; set; }
        public string RoomTitle { get; set; }
        [Required(ErrorMessage ="Lütfen yatak sayısını giriniz")]
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
