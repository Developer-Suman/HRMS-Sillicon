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
    public class ResignationServiceImpl : IResignationService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;

        public ResignationServiceImpl(UnitOfWorkRepoImpl unitOfWorkRepoImpl)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
          //  _resignationIMapper = resignationIMapper;
        }
        public void active(int resignation_id)
        {
            try
            {
                var resignation = _unitOfWorkRepoImpl.Repository<Resignation>().getById(resignation_id);
                if (resignation == null)
                    throw new Exception();

                resignation.Active();
                _unitOfWorkRepoImpl.Repository<Resignation>().update(resignation);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void delete(int resignation_id)
        {
            try
            {
                var resignation = _unitOfWorkRepoImpl.Repository<Resignation>().getById(resignation_id);
                if (resignation == null)
                    throw new Exception();

                _unitOfWorkRepoImpl.Repository<Resignation>().delete(resignation);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void inactive(int resignation_id)
        {
            try
            {
                var resignation = _unitOfWorkRepoImpl.Repository<Resignation>().getById(resignation_id);
                if (resignation == null)
                    throw new Exception();

                resignation.Inactive();
                _unitOfWorkRepoImpl.Repository<Resignation>().update(resignation);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void save(ResignationViewModel resignationViewModel)
        {
            try
            {
                Resignation resignation = new Resignation();
            //    _resignationIMapper.copy(resignation, resignationViewModel);
                _unitOfWorkRepoImpl.Repository<Resignation>().insert(resignation);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void update(ResignationViewModel resignationViewModel)
        {
            try
            {
                Resignation resignation = new Resignation();
              //  _resignationIMapper.copy(resignation, resignationViewModel);
                _unitOfWorkRepoImpl.Repository<Resignation>().update(resignation);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
