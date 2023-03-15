using EllipticCurve.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class DepartmentViewModel
    {
        public int Department_id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
       
        public string? Department_name { get; set; }
        public bool Is_Active { get; set; } = true;
    }




}
