using AutoMapper;
using HRMS_Silicon.Data;
using HRMS_Silicon.Models;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Service.ServiceImpl
{
    public class PayrollService : IPayrollService
    {
        ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PayrollService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public List<EmployeeViewModel> GetAllEmployeeSalaryDetail()
        {
            try
            {
                List<Employee> emplst = _db.EmployeeModels.ToList();
                List<EmployeeViewModel> empvmlst = new List<EmployeeViewModel>();
                foreach (var item in emplst)
                {
                    Department department = _db.DepartmentModels.Single(x => x.Department_id == item.Department_id);
                    Designation designation = _db.DesignationModels.Single(x => x.Designation_id == item.Designation_id);
                    EmployeeViewModel EVM = _mapper.Map<EmployeeViewModel>(item);
                    EVM.DepartmentViewModel = _mapper.Map<DepartmentViewModel>(department);
                    EVM.DesignationViewModel = _mapper.Map<DesignationViewModel>(designation);
                    empvmlst.Add(EVM);
                }
                return empvmlst;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public EmployeeViewModel GEtEmployeeDetailsById(int EmployeeId)
        {
            try
            {
                Employee employee = _db.EmployeeModels.Where(x => x.Employee_id == EmployeeId).Include(x => x.DepartmentModel).Include(x => x.DesignationModel).FirstOrDefault();
                EmployeeViewModel EVM = _mapper.Map<EmployeeViewModel>(employee);
                EVM.DepartmentViewModel = _mapper.Map<DepartmentViewModel>(employee.DepartmentModel);
                EVM.DesignationViewModel = _mapper.Map<DesignationViewModel>(employee.DesignationModel);
                return EVM;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployeeViewModel GetEmployeeSalaryDetailsById(int EmployeeId)
        {
            try
            {
                Employee employee = _db.EmployeeModels.Where(x => x.Employee_id == EmployeeId).Include(x => x.DepartmentModel).Include(x => x.DesignationModel).Include(x => x.EmployeeSalaryDetails).FirstOrDefault();

                EmployeeViewModel EVM = _mapper.Map<EmployeeViewModel>(employee);
                EVM.DepartmentViewModel = _mapper.Map<DepartmentViewModel>(employee.DepartmentModel);
                EVM.DesignationViewModel = _mapper.Map<DesignationViewModel>(employee.DesignationModel);
                foreach (var item in employee.EmployeeSalaryDetails)
                {
                    SalaryDetail salaryDetail = _db.salaryDetails.Single(x => x.SalaryDetailId == item.SalaryDetailId);
                    SalaryDetailVM SDVM = _mapper.Map<SalaryDetailVM>(salaryDetail);
                    EVM.SalaryDetaillst.Add(SDVM);
                }

                return EVM;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateEmployeeSalaryDetails(SalaryDetailVM SDVM)
        {
            try
            {
                if (SDVM.SalaryStatus)
                {
                    List<EmployeeSalaryDetail> ESDlst = _db.EmployeeSalaryDetails.Where(x => x.Employee_id == SDVM.Employee_id).ToList();
                    foreach (var item in ESDlst)
                    {
                        SalaryDetail DbSalary = _db.salaryDetails.Single(x => x.SalaryDetailId == item.SalaryDetailId);
                        DbSalary.SalaryStatus = false;

                        _db.salaryDetails.Update(DbSalary);
                        _db.SaveChanges();
                    }
                    SDVM.SalaryImplementingDate = DateTime.Now;
                }

                SalaryDetail salaryDetail = _mapper.Map<SalaryDetail>(SDVM);
                _db.salaryDetails.Add(salaryDetail);
                _db.SaveChanges();

                EmployeeSalaryDetail employeeSalaryDetail = new EmployeeSalaryDetail()
                {
                    Employee_id = SDVM.Employee_id,
                    SalaryDetailId = salaryDetail.SalaryDetailId
                };
                _db.EmployeeSalaryDetails.Add(employeeSalaryDetail);
                _db.SaveChanges();



            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EditSalaryDetail(SalaryDetailVM SDVM)
        {
            try
            {
                if (SDVM.SalaryStatus)
                {
                    List<EmployeeSalaryDetail> ESDlst = _db.EmployeeSalaryDetails.Where(x => x.Employee_id == SDVM.Employee_id).ToList();
                    foreach (var item in ESDlst)
                    {
                        if (item.SalaryDetailId!=SDVM.SalaryDetailId)
                        {
                            SalaryDetail DbSalary = _db.salaryDetails.Single(x => x.SalaryDetailId == item.SalaryDetailId);
                            DbSalary.SalaryStatus = false;

                            _db.salaryDetails.Update(DbSalary);
                            _db.SaveChanges();
                        }
                    }
                    SDVM.SalaryImplementingDate = DateTime.Now;
                }
                SalaryDetail salaryDetail = _mapper.Map<SalaryDetail>(SDVM);
                _db.salaryDetails.Update(salaryDetail);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteSalaryDetail(int SalaryDetailId)
        {
            try
            {
                SalaryDetail salaryDetail = _db.salaryDetails.Find(SalaryDetailId);
                _db.salaryDetails.Remove(salaryDetail);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
