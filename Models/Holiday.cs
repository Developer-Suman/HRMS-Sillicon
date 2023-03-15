using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("Holiday", Schema = "hrms")]
    public class Holiday
    {
        [Key]
        public int Holiday_Id { get; set; }
        public DateTime HolidayDate { get; set; }
        public string HolidayName { get; set; }
        public string Description { get; set; }
    }
}
