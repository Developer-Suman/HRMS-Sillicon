using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class NoticeIndexViewModel
    {
        public NoticeViewModel Notice { get; set; }
        public List<NoticeViewModel> Notices { get; set; }
        public PaginatedList<NoticeViewModel> NoticePagedList { get; set; }
    }
}
