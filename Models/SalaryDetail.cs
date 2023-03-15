using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("SalaryDetail", Schema = "hrms")]
    public class SalaryDetail
    {
        public SalaryDetail()
        {
            EmployeeSalaryDetails = new HashSet<EmployeeSalaryDetail>();
        }
        [Key]
        public int SalaryDetailId { get; set; }
        public string EmployeeSalary { get; set; }
        public DateTime SalaryImplementingDate { get; set; }
        public bool SalaryStatus { get; set; }
        public virtual ICollection<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; }
    }
}
