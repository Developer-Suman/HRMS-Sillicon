using HRMS_Silicon.Models;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class AttendenceViewModelDetails
    {
        public PaginatedList<AttendenceViewModel> AttendencePaginatedVM { get; set; }
        public List<AttendenceViewModel> AttendenceViewModels { get; set; }
        public AttendenceViewModel AttendenceVM { get; set; }
    }
    public class AttendenceViewModel
    {
        public AttendenceViewModel()
        {
            EmployeeViewModel = new EmployeeViewModel();
        }
        public int Attendence_id { get; set; }
        public DateTime Current_Date { get; set; } = DateTime.Now;

        public DateTime Turn_In { get; set; } = DateTime.Now;
        public DateTime Turn_Out { get; set; } = DateTime.Now;
        public string TotalHours { get; set; }
        public TimeSpan TotalWorkingHours { get; set; }
        public int Employee_id { get; set; }
        public List<Employee> Employees { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public virtual EmployeeViewModel EmployeeViewModel { get; set; }

        public bool Is_Active { get; set; } = true;

    }
}
