using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class DesignationIndexVM
    {
        public DesignationViewModel DesignationViewModel { get; set; }
        public List<DesignationViewModel> DesignationViewModels { get; set; }
        public PaginatedList<DesignationViewModel> DesignationPagedList { get; set; }
    }
}
