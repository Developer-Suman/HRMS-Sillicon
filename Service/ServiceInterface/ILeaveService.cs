using HRMS_Silicon.Models;
using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public interface ILeaveService
    {
        List<LeaveViewModel> GetAll();
        LeaveViewModel Save(LeaveViewModel leaveViewModel);
        void Update(LeaveViewModel leaveViewModel);
        void Delete(int Leave_id);
        LeaveViewModel GetById(int Leave_id);
        List<LeaveViewModel> GetByEmployeeId(int employeeId);
        LeaveViewModel ChangeLeaveStatus(int Leave_id,string status);
        string TotalLeaveDayes(LeaveViewModel leaveViewModel);
    }
}
