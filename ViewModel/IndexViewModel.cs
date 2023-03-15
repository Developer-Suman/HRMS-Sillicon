using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            holidaylst = new List<HolidayViewModel>();
            noticelst = new List<NoticeViewModel>();
            totalemployeelst = new List<EmployeeViewModel>();
            totaldesignationlst = new List<DesignationViewModel>();
        }
        public List<HolidayViewModel> holidaylst { get; set; }
        public List<NoticeViewModel> noticelst { get; set; }

        public List <EmployeeViewModel> totalemployeelst { get; set; }

        public List<DesignationViewModel> totaldesignationlst { get; set; }
    }
}
