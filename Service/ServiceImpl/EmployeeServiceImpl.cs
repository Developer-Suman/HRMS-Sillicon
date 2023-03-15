using AutoMapper;
using HRMS_Silicon.Models;
using HRMS_Silicon.Repository.RepoImplementation;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceImpl
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;


        public EmployeeServiceImpl(IMapper mapper, UnitOfWorkRepoImpl unitOfWorkRepoImpl, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public List<EmployeeViewModel> GetAll()
        {
            try
            {
                var employee = _unitOfWorkRepoImpl.Repository<Employee>().getAll();
                //var activeEmployee = employee.Where(x => x.RecStatus == 'A').ToList();
               
                List<EmployeeViewModel> employeeViewModel = Mapping(employee);
                return employeeViewModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        private List<EmployeeViewModel> Mapping(List<Employee> employeeModels)
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (var items in employeeModels)
            {
                var employeeViewModel = _mapper.Map<EmployeeViewModel>(items);

                employeeViewModels.Add(employeeViewModel);
            }
            return employeeViewModels;
        }

        public EmployeeViewModel GetById(int Employee_id)
        {
            try
            {
                var employee = _unitOfWorkRepoImpl.Repository<Employee>().getById(Employee_id);
                EmployeeViewModel employeeVM = _mapper.Map<EmployeeViewModel>(employee);
                return employeeVM;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public ApplicationUser GetByUsername(string username)
        {
            try
            {
                var user = _unitOfWorkRepoImpl.Repository<ApplicationUser>().getAll().Where(x=>x.UserName == username).SingleOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void delete(int Employee_id)
        {
            try
            {
                var EmployeeToBeDelated = _unitOfWorkRepoImpl.Repository<Employee>().getById(Employee_id);
               
                _unitOfWorkRepoImpl.Repository<Employee>().delete(EmployeeToBeDelated);
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public bool ChangeEmployeeStatus(int Employee_id)
        {
            try
            {
                var employee = _unitOfWorkRepoImpl.Repository<Employee>().getById(Employee_id);

                if (employee == null)
                    throw new Exception();

                if (employee.Is_Active == true)
                {
                    employee.Is_Active = false;

                }
                else if(employee.Is_Active == false)
                {
                    employee.Is_Active = true;
                }

                _unitOfWorkRepoImpl.Repository<Employee>().update(employee);
                _unitOfWorkRepoImpl.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void save(EmployeeViewModel employeeViewModel)
        {
            try
            {
                employeeViewModel.Image = UploadFile(employeeViewModel);
                var EmployeeToBeInserted = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWorkRepoImpl.Repository<Employee>().insert(EmployeeToBeInserted);
                _unitOfWorkRepoImpl.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private string UploadFile(EmployeeViewModel employeeViewModel)
        {
            string fileName = null;
            if (employeeViewModel.File != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "_" + employeeViewModel.File.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    employeeViewModel.File.CopyTo(fileStream);
                }

            }
            else
            {
                fileName = employeeViewModel.Image;
                /*Employee employee = new Employee();
                fileName = employee.Image;*/
            }

            return fileName;
        }

        public void update(EmployeeViewModel employeeViewModel)
        {
            try
            {
                employeeViewModel.Image = UploadFile(employeeViewModel);
                Employee employee = new Employee();
                var EmployeeToBeUpdated = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWorkRepoImpl.Repository<Employee>().update(EmployeeToBeUpdated);
                //_unitOfWorkRepoImpl.Repository<Employee>().State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _unitOfWorkRepoImpl.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //public ApplicationUser GetByUsername(string username)
        //{
        //    try
        //    {
        //        var user = _unitOfWorkRepoImpl.Repository<ApplicationUser>().getAll().Where(x => x.UserName == username).SingleOrDefault();
        //        return user;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }
        //}


        //public string GetFullnameByUserId(string Id)
        //{
        //    var user = _applicationDbContext.Users.Include(x => x.Employee).Where(x => x.Id == Id).FirstOrDefault();
        //    return user.Fullname;
        //}

    }
}