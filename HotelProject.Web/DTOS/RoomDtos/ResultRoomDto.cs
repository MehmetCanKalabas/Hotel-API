namespace HotelProject.Web.DTOS.RoomDtos
{
    public class ResultRoomDto
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        public decimal RoomPrice { get; set; }
        public string RoomTitle { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
