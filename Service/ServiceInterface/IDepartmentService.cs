using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public  interface IDepartmentService
    {
        void save(DepartmentViewModel departmentViewModel);
        void update(DepartmentViewModel departmentViewModel);
        DepartmentViewModel GetById(int Department_id);

        List<DepartmentViewModel> GetAll();
        void delete(int id);

        void ToogleStatus(int Department_id);
        //void active(int Department_id);
        //void inactive(int Department_id);

    }
}
