using HRMS_Silicon.Enum;
using HRMS_Silicon.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("Employee", Schema = "hrms")]

    public class Employee
    {
        public Employee()
        {
            EmployeeSalaryDetails = new HashSet<EmployeeSalaryDetail>();
        }
        [Key]
        public int Employee_id { get; set; }

        public int? Department_id { get; set; }
        [ForeignKey("Department_id")]
        public virtual Department DepartmentModel { get; set; }

        public int? Designation_id { get; set; }
        [ForeignKey("Designation_id")]
        public virtual Designation DesignationModel { get; set; }


        [Display(Name = "Full Name")]

        public string FullName => First_name + " " + Last_name;

        [Required]
        public string First_name { get; set; }

        [Required]
        public string Last_name { get; set; }

        [Required]
        public string EmployeeNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact_1 { get; set; }
        public string Contact_2 { get; set; }

        public MaritalStatusEnum Marital_status { get; set; }

        public GenderEnum GenderEnum { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]

        public DateTime Joining_date { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public bool Is_Active { get; set; } = true;
        //public bool HasUser { get;}

        public virtual ICollection<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; }
        public void Active()
        {
            Is_Active = true;
        }
        public void Inactive()
        {
            Is_Active = false;
        }

        //public char RecStatus { get; set; } = 'A';
    }
}
