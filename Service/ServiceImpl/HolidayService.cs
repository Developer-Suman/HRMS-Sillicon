using AutoMapper;
using HRMS_Silicon.Models;
using HRMS_Silicon.Repository.RepoImplementation;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceImpl
{
    public class HolidayService : IHolidayService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;
        private readonly IMapper _mapper;

        public HolidayService(UnitOfWorkRepoImpl unitOfWorkRepoImpl, IMapper mapper)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
            _mapper = mapper;
        }
        public List<HolidayViewModel> GetAll()
        {
            try
            {
                List<Holiday> holidaylst = _unitOfWorkRepoImpl.Repository<Holiday>().getAll();
                List<HolidayViewModel> HVMlst = new List<HolidayViewModel>();
                foreach (var item in holidaylst)
                {
                    HolidayViewModel HVM = _mapper.Map<HolidayViewModel>(item);
                    HVMlst.Add(HVM);
                }
                return HVMlst;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void Save(HolidayViewModel HVM)
        {
            try
            {
                Holiday holiday = _mapper.Map<Holiday>(HVM);
                _unitOfWorkRepoImpl.Repository<Holiday>().insert(holiday);
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void Update(HolidayViewModel HVM)
        {
            try
            {
                Holiday holiday = _mapper.Map<Holiday>(HVM);
                _unitOfWorkRepoImpl.Repository<Holiday>().update(holiday);
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public void Delete(int Holiday_Id)
        {
            try
            {
                Holiday holiday = _unitOfWorkRepoImpl.Repository<Holiday>().getById(Holiday_Id);
                if (holiday != null)
                {
                    _unitOfWorkRepoImpl.Repository<Holiday>().delete(holiday);
                    _unitOfWorkRepoImpl.Commit();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public HolidayViewModel GetById(int Holiday_Id)
        {
            try
            {
                HolidayViewModel HVM = new HolidayViewModel();
                Holiday holiday = _unitOfWorkRepoImpl.Repository<Holiday>().getById(Holiday_Id);
                if (holiday!=null)
                {
                    HVM = _mapper.Map<HolidayViewModel>(holiday);
                }
                return HVM;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
