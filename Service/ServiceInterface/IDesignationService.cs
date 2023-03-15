using HRMS_Silicon.Models;
using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public interface IDesignationService
    {
        void save(DesignationViewModel designationViewModel);
        void update(DesignationViewModel designationViewModel);
        List<DesignationViewModel> GetAll();

        void delete(int id);
        DesignationViewModel GetById(int designation_id);
    }
}
