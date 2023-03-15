using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class NoticeViewModel    
    {
        public int NoticeId { get; set; }
        public DateTime NoticeDate { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        public bool isActive { get; set; }
    }
}
