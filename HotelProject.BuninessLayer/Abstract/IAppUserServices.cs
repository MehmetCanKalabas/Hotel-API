using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BuninessLayer.Abstract
{
    public interface IAppUserServices: IGenericServices<AppUser>
    {
        public List<AppUser> TUserListWithLocation();

    }
}
