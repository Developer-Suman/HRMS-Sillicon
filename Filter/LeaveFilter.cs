using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Filter
{
    public class LeaveFilter
    {
        public string EmployeeNameForSearch { get; set; }
        [DataType(DataType.Date)]

        public DateTime Date_fromForSearch { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]

        public DateTime Date_toForSearch { get; set; } = DateTime.Now;
    }
}
