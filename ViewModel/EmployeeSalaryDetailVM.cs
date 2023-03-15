using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class EmployeeSalaryDetailVM
    {
        public int Employee_id { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public int SalaryDetailId { get; set; }
        public SalaryDetailVM SalaryDetail { get; set; }
    }
}
