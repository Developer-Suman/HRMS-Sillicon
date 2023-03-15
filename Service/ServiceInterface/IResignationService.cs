using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public interface IResignationService
    {
        void save(ResignationViewModel resignationViewModel);
        void update(ResignationViewModel resignationViewModel);
        void delete(int resignation_id);
        void active(int resignation_id);
        void inactive(int resignation_id);
    }
}
