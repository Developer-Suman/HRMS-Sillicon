using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    public class IndexVM
    {
        public List<DepartmentViewModel> departmentViewModels { get; set; } 
        public DepartmentViewModel departmentViewModel { get; set; }

    }
} 
