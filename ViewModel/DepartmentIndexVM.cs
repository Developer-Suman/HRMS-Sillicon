using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class DepartmentIndexVM
    {
        public DepartmentViewModel DepartmentViewModel { get; set; }
        public List<DepartmentViewModel> DepartmentViewModels { get; set; }

        public PaginatedList<DepartmentViewModel> DepartmentPagedList { get; set; }
    }
}
