using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BuninessLayer.Abstract
{
    public interface IBookingServices: IGenericServices<Booking>
    {
        void TBookingStatusChangeApproved(int id);
        void TBookingStatusChangeCansel(int id);
        void TBookingStatusChangeWait(int id);


    }
}
