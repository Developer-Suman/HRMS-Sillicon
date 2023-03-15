using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("Designation", Schema = "hrms")]

    public class Designation
    {
        [Key]
        public int Designation_id { get; set; }
       
        [Required]
        public string Designation_name { get; set; }

        //public char RecStatus { get; set; } = 'A';
    }

    
}
