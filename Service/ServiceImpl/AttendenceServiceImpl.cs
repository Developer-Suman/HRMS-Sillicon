using AutoMapper;
using HRMS_Silicon.Models;
using HRMS_Silicon.Repository.RepoImplementation;
using HRMS_Silicon.Repository.RepoInterface;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceImpl
{
    public class AttendenceServiceImpl: IAttendenceService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;
        private readonly IMapper _mapper;

        public AttendenceServiceImpl(UnitOfWorkRepoImpl unitOfWorkRepoImpl,IMapper mapper)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
            _mapper = mapper;
        }

        public List<AttendenceViewModel> GetAll()
        {
            try
            {
                var attendence = _unitOfWorkRepoImpl.Repository<Attendence>().getAll();
                List<AttendenceViewModel> attendenceViewModels = Mapping(attendence);
                return attendenceViewModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private List<AttendenceViewModel> Mapping(List<Attendence> attendenceModels)
        {
            List<AttendenceViewModel> attendenceViewModels = new List<AttendenceViewModel>();
            foreach (var items in attendenceModels)
            {
                var attendenceViewModel = _mapper.Map<AttendenceViewModel>(items);
                attendenceViewModel.TotalHours = items.TotalHours;
                attendenceViewModels.Add(attendenceViewModel);
            }
            return attendenceViewModels;
        }

        public void Present(int Attendence_id)
        {
            try
            {
                var attendence = _unitOfWorkRepoImpl.Repository<Attendence>().getById(Attendence_id);
                if (attendence == null)
                    throw new Exception();

                attendence.Active();
                _unitOfWorkRepoImpl.Repository<Attendence>().update(attendence);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int Attendence_id)
        {
             try
            {
                var attendence = _unitOfWorkRepoImpl.Repository<Attendence>().getById(Attendence_id);
                if (attendence == null)
                    throw new Exception();

                _unitOfWorkRepoImpl.Repository<Attendence>().delete(attendence);

            }
            catch (Exception)
            {

                throw;
            }       
        }

        public void Absent(int Attendence_id)
        {
            try
            {
                var attendence = _unitOfWorkRepoImpl.Repository<Attendence>().getById(Attendence_id);
                if (attendence == null)
                    throw new Exception();

                attendence.Inactive();
                _unitOfWorkRepoImpl.Repository<Attendence>().update(attendence);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Save(AttendenceViewModel attendenceViewModel)
        {
            try
            {
                attendenceViewModel.TotalHours = TotalWorkingHours(attendenceViewModel);
                var AttendenceToBeInserted = _mapper.Map<Attendence>(attendenceViewModel);
                _unitOfWorkRepoImpl.Repository<Attendence>().insert(AttendenceToBeInserted);
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(AttendenceViewModel attendenceViewModel)
        {
            try
            {
                attendenceViewModel.TotalHours = TotalWorkingHours(attendenceViewModel);
                var AttendenceToBeUpdated = _mapper.Map<Attendence>(attendenceViewModel);
                _unitOfWorkRepoImpl.Repository<Attendence>().update(AttendenceToBeUpdated);
                _unitOfWorkRepoImpl.Commit();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string TotalWorkingHours(AttendenceViewModel attendenceViewModel)
        {
            try
            {
                TimeSpan timeSpan = attendenceViewModel.TotalWorkingHours;
                string totalhour = "1";
                if (attendenceViewModel.Turn_In == attendenceViewModel.Turn_Out)
                    totalhour = "1";
                else
                {
                    timeSpan = attendenceViewModel.Turn_Out - attendenceViewModel.Turn_In;
                    totalhour = Convert.ToString(timeSpan);
                }

                return totalhour;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
