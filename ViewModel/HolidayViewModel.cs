using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class HolidayViewModel
    {
        public int Holiday_Id { get; set; }
        [Required]
        public DateTime HolidayDate { get; set; }
        [Required]
        public string HolidayName { get; set; }

        public string Description { get; set; }
    }
}
