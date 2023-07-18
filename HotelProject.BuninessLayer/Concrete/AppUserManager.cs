using HotelProject.BuninessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BuninessLayer.Concrete
{
    
    public class AppUserManager : IAppUserServices
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TDelete(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser TGetByID(int id)
        {
            return _appUserDal.GetByID(id);
        }

        public List<AppUser> TGetList()
        {
            return _appUserDal.GetList();
        }

        public void TInsert(AppUser t)
        {
            _appUserDal.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
            _appUserDal.Update(t);
        }

        public List<AppUser> TUserListWithLocation()
        {
            return _appUserDal.UserListWithLocation();
        }
    }
}
