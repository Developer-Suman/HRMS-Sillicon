using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class SalaryDetailVM
    {
        public SalaryDetailVM()
        {
            EmployeeSalaryDetails = new List<EmployeeSalaryDetailVM>();
        }
        public int SalaryDetailId { get; set; }
        [Required]
        public string EmployeeSalary { get; set; }
        [Required]
        public DateTime SalaryImplementingDate { get; set; }
        public bool SalaryStatus { get; set; }
        public List<EmployeeSalaryDetailVM> EmployeeSalaryDetails { get; set; }
        [Required(ErrorMessage = "Please Select the Employee!!!")]
        public int Employee_id { get; set; }
    }
}
