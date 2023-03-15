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
    public class DepartmentServiceImpl : IDepartmentService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;
        private readonly IMapper _mapper;


        public DepartmentServiceImpl(UnitOfWorkRepoImpl unitOfWorkRepoImpl, IMapper mapper)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
            _mapper = mapper;
        }

        public List<DepartmentViewModel> GetAll()
        {
            try
            {
                var departmentModels = _unitOfWorkRepoImpl.Repository<Department>().getAll();
                //var departmentActive = departmentModels.Where(x => x.RecStatus == 'A').ToList();

                List<DepartmentViewModel> departmentViewModel = Mapping(departmentModels);

                return departmentViewModel;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private List<DepartmentViewModel> Mapping(List<Department> departmentModels)
        {
            List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();

            foreach (var items in departmentModels)
            {
                var departmentViewModel = _mapper.Map<DepartmentViewModel>(items);

                departmentViewModels.Add(departmentViewModel);
            }
            return departmentViewModels;
        }


        //public List<DepartmentViewModel> GetAll()
        //{
        //    try
        //    {
        //        List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();
        //        var departmentModels = _unitOfWorkRepoImpl.Repository<DepartmentModels>().getAll();

        //        for (int i = 0; i < departmentModels.Count; i++)
        //        {

        //            departmentViewModels.Add(new DepartmentViewModel());

        //            _departmentIMapper.map(departmentViewModels[i], departmentModels[i]);
        //        }
        //        return departmentViewModels;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}




        public void delete(int id)
        {
            try
            {
                var departmentToBeDeleted = _unitOfWorkRepoImpl.Repository<Department>().getById(id);
                _unitOfWorkRepoImpl.Repository<Department>().delete(departmentToBeDeleted);
                _unitOfWorkRepoImpl.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public bool ToogleStatus(int Department_id)
        {
            try
            {
                var checkEmployee = _unitOfWorkRepoImpl.Repository<Employee>().Where(x=>x.Department_id == Department_id);
                /*ar checkEmployees = checkEmployee.SingleOrDefault();*/

                if(checkEmployee != null)
                {
                    return false;
                }
                else
                {
                    var department = _unitOfWorkRepoImpl.Repository<Department>().getById(Department_id);
                    if (department.Is_Active)
                    {
                        department.Is_Active = false;
                    }
                    else
                    {
                        department.Is_Active = true;
                    }

                    _unitOfWorkRepoImpl.Repository<Department>().update(department);
                    _unitOfWorkRepoImpl.Commit();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void save(DepartmentViewModel departmentViewModel)
        {
            try
            {
                Department department = new Department();
                var DepartmentToBeInserted = _mapper.Map<Department>(departmentViewModel);
                _unitOfWorkRepoImpl.Repository<Department>().insert(DepartmentToBeInserted);
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void update(DepartmentViewModel departmentViewModel)
        {
            try
            {
                Department department = new Department();
                var DepartmentToBeUpdated = _mapper.Map<Department>(departmentViewModel);
                _unitOfWorkRepoImpl.Repository<Department>().update(DepartmentToBeUpdated);
                _unitOfWorkRepoImpl.Commit();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public DepartmentViewModel GetById(int Department_id)
        {
            try
            {
                var department = _unitOfWorkRepoImpl.Repository<Department>().getById(Department_id);

                DepartmentViewModel departmentVM = _mapper.Map<DepartmentViewModel>(department);
                return departmentVM;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



    }
}