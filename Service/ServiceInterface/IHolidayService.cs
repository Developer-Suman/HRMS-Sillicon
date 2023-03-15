using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public interface IHolidayService
    {
        void Save(HolidayViewModel NVM);
        void Update(HolidayViewModel NVM);
        void Delete(int Holiday_Id);
        List<HolidayViewModel> GetAll();
        HolidayViewModel GetById(int Holiday_Id);   
    }
}
