using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public interface IPayrollService
    {
        void UpdateEmployeeSalaryDetails(SalaryDetailVM SDVM);
        void EditSalaryDetail(SalaryDetailVM SDVM);
        //void Delete(int NoticeId);
        //void ToogleStatus(int NoticeId);
        List<EmployeeViewModel> GetAllEmployeeSalaryDetail();
        EmployeeViewModel GetEmployeeSalaryDetailsById(int EmployeeId);
        EmployeeViewModel GEtEmployeeDetailsById(int EmployeeId);
        bool DeleteSalaryDetail(int SalaryDetailId);
    }
}
