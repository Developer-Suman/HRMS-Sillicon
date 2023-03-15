using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public interface INoticeService
    {
        void Save(NoticeViewModel HVM);
        void Delete(int NoticeId);
        void ToogleStatus(int NoticeId);
        List<NoticeViewModel> GetAll();
        NoticeViewModel GetById(int NoticeId);
    }
}
