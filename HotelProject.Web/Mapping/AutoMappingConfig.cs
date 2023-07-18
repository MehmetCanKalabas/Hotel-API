using HotelProject.EntityLayer.Concrete;
using HotelProject.Web.DTOS.ServiceDtos;
using AutoMapper;
using HotelProject.Web.DTOS.RegisterDtos;
using HotelProject.Web.DTOS.Login_Dtos;
using HotelProject.Web.DTOS.AboutDtos;
using HotelProject.Web.DTOS.RoomDtos;
using HotelProject.Web.DTOS.TestimonialDtos;
using HotelProject.Web.DTOS.StaffDtos;
using HotelProject.Web.DTOS.SubscribeDtos;
using HotelProject.Web.DTOS.BookingDtos;
using HotelProject.Web.DTOS.Contact;
using HotelProject.Web.DTOS.GuestDtos;
using HotelProject.Web.DTOS.Contact.SendMessage;
using HotelProject.Web.DTOS.AppUserDtos;

namespace HotelProject.Web.Mapping
{
    public class AutoMappingConfig: Profile
    {
        public AutoMappingConfig()
        {
              CreateMap<ResultServiceDto,Service>().ReverseMap();
              CreateMap<UpdateServiceDto,Service>().ReverseMap();
              CreateMap<CreateServiceDto,Service>().ReverseMap();

              CreateMap<CreateNewUserDto,AppUser>().ReverseMap();

            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
            CreateMap<CreateRoomDto, Room>().ReverseMap();

            CreateMap<ResultGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();
            CreateMap<CreateGuestDto, Guest>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();
            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<GetMessageDto, Contact>().ReverseMap();

            CreateMap<CreateSendMessageDto, SendMessage>().ReverseMap();
            CreateMap<ResultSendMessage, SendMessage>().ReverseMap();

            CreateMap<ResultAppUserDto, AppUser>().ReverseMap();


            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();


        }
    }
}
