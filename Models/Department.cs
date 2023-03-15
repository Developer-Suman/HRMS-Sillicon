using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("Department", Schema = "hrms")]

    public class Department
    {
        [Key]
        public int Department_id { get; set; }

        //[Required(ErrorMessage = "Please enter student name.")]
        [Required]
        [Display(Name = "Department Name")]
        public string? Department_name { get; set; }
        public bool Is_Active { get; set; } =  true;

        //public char RecStatus { get; set; } = 'A';

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
