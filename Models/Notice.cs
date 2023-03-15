using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{
    [Table("Notice", Schema = "hrms")]
    public class Notice
    {
        [Key]
        public int NoticeId { get; set; }
        public DateTime NoticeDate { get; set; }    
        public string Subject { get; set; }
        [MaxLength]
        public string Description { get; set; }
        public bool isActive { get; set; }  
    }
}
