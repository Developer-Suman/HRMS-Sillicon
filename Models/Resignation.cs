using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("Resignation", Schema = "hrms")]
    public class Resignation
    {
        [Key]
        public int Resignation_id { get; set; }
        public string Resignation_name { get; set; }
        public string  Resign_reason { get; set; }
        public DateTime Created_date { get; set; } = DateTime.Now;
       
        public int Employee_id { get; set; }
        [ForeignKey("Employee_id")]
        public virtual Employee EmployeeModel { get; set; }
        
        public bool Is_active { get; set; } = true;

        public void Active()
        {
            Is_active = true;
        }
        public void Inactive()
        {
            Is_active = false;
        }
    }
}
