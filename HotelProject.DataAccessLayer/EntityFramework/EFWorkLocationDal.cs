using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.DTOLayer.DTOS.AppUserWithLocation;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFWorkLocationDal: GenericRepository<WorkLocation>, IWorkLocationDal
    {
        public EFWorkLocationDal(Context context): base(context) 
        {
            
        }

        
    }
}
