using HRMS_Silicon.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("Leave", Schema = "hrms")]

    public class Leave
    {
        [Key]
        public int  Leave_id { get; set; }
        public int Employee_id { get; set; }

        [ForeignKey("Employee_id")]
        public virtual Employee EmployeeFK { get; set; }
        public string Leave_reason { get; set; }

        [DataType(DataType.Date)]
        public DateTime AppliedOnDate { get; set; } = DateTime.Now;
       
        [DataType(DataType.Date)]
        public DateTime Date_from { get; set; } = DateTime.Now;

        
        [DataType(DataType.Date)]
        public DateTime Date_to { get; set; } = DateTime.Now;
        public string Total_days { get; set; }
        public LeaveTypeEnum LeaveTypeEnum { get; set; }
        public LeaveStatus LeaveApproval { get; set; } 
    }
}
