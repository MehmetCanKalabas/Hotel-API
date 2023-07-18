using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DTOLayer.DTOS.WorkLocation
{
    public class UpdateWorkLocationDto
    {
        public int WorkLocationID { get; set; }
        public string workLocationName { get; set; }
        public string workLocationCity { get; set; }
    }
}
