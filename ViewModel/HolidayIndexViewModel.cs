using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class HolidayIndexViewModel
    {
        public HolidayViewModel Holiday { get; set; }
        public List<HolidayViewModel> Holidays { get; set; }
        public PaginatedList<HolidayViewModel>  HolidayPagedList { get; set; }  
    }
}
