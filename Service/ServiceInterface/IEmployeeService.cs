using HRMS_Silicon.Models;
using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public interface IEmployeeService
    {
        void save(EmployeeViewModel employeeViewModel);
        void update(EmployeeViewModel employeeViewModel);
        List<EmployeeViewModel> GetAll();
        EmployeeViewModel GetById(int Employee_id);
        ApplicationUser GetByUsername(string username);
        void delete(int Employee_id);
        bool ChangeEmployeeStatus(int Employee_id);
       
    }
}
