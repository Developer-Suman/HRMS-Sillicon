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
    public class NoticeService : INoticeService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;
        private readonly IMapper _mapper;
        public NoticeService(UnitOfWorkRepoImpl unitOfWorkRepoImpl, IMapper mapper)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
            _mapper = mapper;
        }
        public List<NoticeViewModel> GetAll()
        {
            try
            {
                List<Notice> noticelst = _unitOfWorkRepoImpl.Repository<Notice>().getAll();
                List<NoticeViewModel> NVMlst = new List<NoticeViewModel>();
                foreach (var item in noticelst)
                {
                    NoticeViewModel NVM = _mapper.Map<NoticeViewModel>(item);
                    NVMlst.Add(NVM);
                }
                return NVMlst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public NoticeViewModel GetById(int NoticeId)
        {
            try
            {
                NoticeViewModel NVM = new NoticeViewModel();
                Notice notice = _unitOfWorkRepoImpl.Repository<Notice>().getById(NoticeId);
                if (notice != null)
                {
                    NVM = _mapper.Map<NoticeViewModel>(notice);
                }
                return NVM;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void Save(NoticeViewModel NVM)
        {
            try
            {
                Notice notice = _mapper.Map<Notice>(NVM);
                _unitOfWorkRepoImpl.Repository<Notice>().insert(notice);
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public void Delete(int NoticeId)
        {
            try
            {
                Notice notice = _unitOfWorkRepoImpl.Repository<Notice>().getById(NoticeId);
                if (notice != null)
                {
                    _unitOfWorkRepoImpl.Repository<Notice>().delete(notice);
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

        public void ToogleStatus(int NoticeId)
        {
            try
            {
                Notice notice = _unitOfWorkRepoImpl.Repository<Notice>().getById(NoticeId);
                if (notice.isActive)
                {
                    notice.isActive = false;
                }
                else
                {
                    notice.isActive = true;
                }
                _unitOfWorkRepoImpl.Repository<Notice>().update(notice);
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
