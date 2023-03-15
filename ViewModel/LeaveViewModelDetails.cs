using HRMS_Silicon.Enum;
using HRMS_Silicon.Filter;
using HRMS_Silicon.Models;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class LeaveViewModelDetails
    {
        public PaginatedList<LeaveViewModel> LeavePaginatedVM { get; set; }
        public List<LeaveViewModel> LeaveViewModels { get; set; }
        public LeaveViewModel LeaveVM { get; set; }
        public LeaveFilter LeaveFilter { get; set; }
    }
    public class LeaveViewModel
    {
        public LeaveViewModel()
        {
            EmployeeViewModel = new EmployeeViewModel();
        }
        public int Leave_id { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public int Employee_id { get; set; }
        public List<Employee> Employees { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Employee Name")]
        public EmployeeViewModel EmployeeViewModel { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public string Leave_reason { get; set; }
        public DateTime AppliedOnDate { get; set; } = DateTime.Now;
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime Date_from { get; set; } = DateTime.Now;
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime Date_to { get; set; } = DateTime.Now;
        public string TotalDays { get; set; }

       

        public TimeSpan TotalLeaveDays { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public LeaveTypeEnum LeaveTypeEnum { get; set; }
        public LeaveStatus LeaveApproval { get; set; }

    }

}
