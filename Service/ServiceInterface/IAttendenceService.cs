using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public interface IAttendenceService
    {
        void Save(AttendenceViewModel attendenceViewModel);
        void Update(AttendenceViewModel attendenceViewModel);
        void Delete(int Attendence_id);
        void Present(int Attendence_id);
        void Absent(int Attendence_id);
        List<AttendenceViewModel> GetAll();
    }
}
