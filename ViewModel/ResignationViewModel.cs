using HRMS_Silicon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class ResignationViewModel
    {
        public int resignation_id { get; set; }
        public string resignation_name { get; set; }
        public string resign_reason { get; set; }
        public DateTime created_date { get; set; } = DateTime.Now;

        public int employee_id { get; set; }
        public virtual Employee employeeModel { get; set; }

        public bool is_active { get; set; } = true;
    }
}
