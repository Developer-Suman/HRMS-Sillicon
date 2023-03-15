using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class DesignationViewModel
    {
        public int Designation_id { get; set; }
        [Required]
        [Display(Name = "Designation Name")]
        public string Designation_name { get; set; }
    }
  
}
