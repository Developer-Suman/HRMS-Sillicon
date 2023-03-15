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
    public class DesignationServiceImpl : IDesignationService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;
        private readonly IMapper _mapper;

        public DesignationServiceImpl(UnitOfWorkRepoImpl unitOfWorkRepoImpl, IMapper mapper)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
            _mapper = mapper;
        }

        public List<DesignationViewModel> GetAll()
        {
            try
            {
                var designationModels = _unitOfWorkRepoImpl.Repository<Designation>().getAll();
                //var designationActive = designationModels.Where(x=>x.RecStatus == 'A').ToList();

                List<DesignationViewModel> designationViewModel = Mapping(designationModels);

                return designationViewModel;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                throw;
            }
        }
        private List<DesignationViewModel> Mapping(List<Designation> designationModels)
        {
            List<DesignationViewModel> designationViewModels = new List<DesignationViewModel>();

            foreach (var items in designationModels)
            {                
                var designationViewModel = _mapper.Map<DesignationViewModel>(items); 

                designationViewModels.Add(designationViewModel);
            }
            return designationViewModels;
        }

        public void delete(int id)
        {
            try
            {
               var designationTobeDeleted = _unitOfWorkRepoImpl.Repository<Designation>().getById(id);
                _unitOfWorkRepoImpl.Repository<Designation>().delete(designationTobeDeleted);
                _unitOfWorkRepoImpl.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ;
            }
        }

        public void save(DesignationViewModel designationViewModel)
        {
            try
            {
                Designation designation = new Designation();
                var item = _mapper.Map<Designation>(designationViewModel);
                _unitOfWorkRepoImpl.Repository<Designation>().insert(item);
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void update(DesignationViewModel designationViewModel)
        {
            try
            {
                Designation designation = new Designation();
                var item = _mapper.Map<Designation>(designationViewModel);
                _unitOfWorkRepoImpl.Repository<Designation>().update(item);
                _unitOfWorkRepoImpl.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;                
            }
        }

        public DesignationViewModel GetById(int designation_id)
        {
            try
            {
                var designation = _unitOfWorkRepoImpl.Repository<Designation>().getById(designation_id);

                DesignationViewModel designationVM = _mapper.Map<DesignationViewModel>(designation);
                return designationVM;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
