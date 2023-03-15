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
    public class LeaveServiceImpl : ILeaveService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;
        private readonly IMapper _mapper;

        public LeaveServiceImpl(UnitOfWorkRepoImpl unitOfWorkRepoImpl,IMapper mapper)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
            _mapper = mapper;
        }

        public List<LeaveViewModel> GetAll()
        {
            try
            {
                var leave = _unitOfWorkRepoImpl.Repository<Leave>().getAll();               
                List<LeaveViewModel> leaveViewModels = Mapping(leave);
                return leaveViewModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private List<LeaveViewModel> Mapping(List<Leave> leaveModels)
        {
            List<LeaveViewModel> leaveViewModels = new List<LeaveViewModel>();
            foreach (var items in leaveModels)
            {               
                var leaveViewModel = _mapper.Map<LeaveViewModel>(items);
                leaveViewModel.TotalDays = items.Total_days;
                leaveViewModels.Add(leaveViewModel);
            }
            return leaveViewModels;
        }

        public LeaveViewModel ChangeLeaveStatus(int Leave_id,string status)
        {
            try
            {
                var leave = _unitOfWorkRepoImpl.Repository<Leave>().getById(Leave_id);

                LeaveViewModel leaveVM = _mapper.Map<LeaveViewModel>(leave);


                if (leave == null)
                    throw new Exception();

                if (status == "Approve")
                {
                    leave.LeaveApproval = Enum.LeaveStatus.Approved;
                    leaveVM.LeaveApproval = leave.LeaveApproval;
                }
                else if (status == "Reject")
                {
                    leave.LeaveApproval = Enum.LeaveStatus.Rejected;
                    leaveVM.LeaveApproval = leave.LeaveApproval;
                }
                else if (status == "Pending")
                {
                    leave.LeaveApproval = Enum.LeaveStatus.Pending;
                    leaveVM.LeaveApproval = leave.LeaveApproval;

                }

                _unitOfWorkRepoImpl.Repository<Leave>().update(leave);
                _unitOfWorkRepoImpl.Commit();

                return leaveVM;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Delete(int Leave_id)
        {
            try
            {
                var leave = _unitOfWorkRepoImpl.Repository<Leave>().getById(Leave_id);       
                _unitOfWorkRepoImpl.Repository<Leave>().delete(leave);
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public LeaveViewModel Save(LeaveViewModel leaveViewModel)
        {
            try
            {
                leaveViewModel.TotalDays = TotalLeaveDayes(leaveViewModel);
                var LeaveToBeInserted = _mapper.Map<Leave>(leaveViewModel);                
                _unitOfWorkRepoImpl.Repository<Leave>().insert(LeaveToBeInserted);
                _unitOfWorkRepoImpl.Commit();
                return leaveViewModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public string TotalLeaveDayes(LeaveViewModel leaveViewModel)
        {
            try
            {
                TimeSpan timeSpan = leaveViewModel.TotalLeaveDays;
                string totalLeave = "";
                
                
                if (leaveViewModel.Date_from.Day == leaveViewModel.Date_to.Day)
                    totalLeave = "1";
                else
                {   
                    timeSpan =  leaveViewModel.Date_to.Subtract(leaveViewModel.Date_from).Add(TimeSpan.FromDays(1));
                    
                    totalLeave = Convert.ToString(timeSpan.TotalDays);
                }    
               
                return totalLeave;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }
        public void Update(LeaveViewModel leaveViewModel)
        {
            try
            {
                leaveViewModel.TotalDays = TotalLeaveDayes(leaveViewModel);
                var LeaveToBeUpdated = _mapper.Map<Leave>(leaveViewModel);
                _unitOfWorkRepoImpl.Repository<Leave>().update(LeaveToBeUpdated);
                _unitOfWorkRepoImpl.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public LeaveViewModel GetById(int Leave_id)
        {
            try
            {
                var leave = _unitOfWorkRepoImpl.Repository<Leave>().getById(Leave_id);
                LeaveViewModel leaveVM = _mapper.Map<LeaveViewModel>(leave);
                leaveVM.TotalDays = leave.Total_days;
                return leaveVM;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<LeaveViewModel> GetByEmployeeId(int employeeId)
        {
            try
            {
                List<LeaveViewModel> leaveViewModels = new();

                List<Leave> rawLeave = _unitOfWorkRepoImpl.Repository<Leave>().Find(x => x.Employee_id == employeeId).ToList();

                foreach (var item in rawLeave)
                {
                    LeaveViewModel leaveVM = _mapper.Map<LeaveViewModel>(item);
                    leaveVM.TotalDays = item.Total_days;
                    leaveViewModels.Add(leaveVM);
                }

                return leaveViewModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

      


    }
}
