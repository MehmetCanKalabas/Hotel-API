using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.DTOLayer.DTOS.AppUserWithLocation;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFAppUserDal: GenericRepository<AppUser>, IAppUserDal
    {
        public EFAppUserDal(Context context): base(context) 
        {
            
        }

        public List<AppUser> UserListWithLocation()
        {
            var context= new Context();
            return context.Users.Include(x => x.WorkLocation).Select(y => new AppUser
            {
                Name = y.Name,
                Surname = y.Surname,
                ImageUrl = y.ImageUrl,
                City = y.City,
                WorkLocationName = y.WorkLocation.workLocationName,
                Department=y.Department,
                Status = y.Status,
                

            }).ToList();
        }
    }
}
