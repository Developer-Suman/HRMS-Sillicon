using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("EmployeeSalaryDetail", Schema = "hrms")]
    public class EmployeeSalaryDetail
    {
        [Key]
        [Column(Order =1)]
        public int Employee_id { get; set; }
        public Employee Employee { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SalaryDetailId { get; set; }
        public SalaryDetail SalaryDetail { get; set; }  
    }
}
