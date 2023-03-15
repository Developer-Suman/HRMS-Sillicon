using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("Attendence", Schema = "hrms")]

    public class Attendence
    {
        [Key]
        public int Attendence_Id { get; set; }
        public DateTime Current_Date { get; set; } = DateTime.Now;
        public DateTime Turn_In { get; set; } = DateTime.Now;
        public DateTime Turn_Out { get; set; } = DateTime.Now;
        public string TotalHours { get; set; }

        public int Employee_id { get; set; }
        [ForeignKey("Employee_id")]
        public  Employee EmployeeData { get; set; }

        public bool Is_Active { get; set; } = true;

        public void Active()
        {
            Is_Active = true;
        }
        public void Inactive()
        {
            Is_Active = false;
        }
    }
}
