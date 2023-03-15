using HRMS_Silicon.Helper;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Controllers
{
    [Authorize]
    public class PayrollController : Controller
    {
        public IPayrollService _ps;
        public PayrollController(IPayrollService ps)
        {
            _ps = ps;
        }
        [HttpGet]
        public IActionResult SalaryDetails(int pageNumber = 1)
        {
            try
            {
                EmployeeViewModelDetails employeeViewModelDetails = new();
                employeeViewModelDetails.EmployeeViewModel = new EmployeeViewModel();

                employeeViewModelDetails.EmployeeViewModels = _ps.GetAllEmployeeSalaryDetail();

                employeeViewModelDetails.EmployeePagedList = PaginatedList<EmployeeViewModel>.Create(employeeViewModelDetails.EmployeeViewModels.AsQueryable(), pageNumber, 5);

                return View(employeeViewModelDetails);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpDateSalary(SalaryDetailVM SDVM)
        {
            try
            {
                _ps.UpdateEmployeeSalaryDetails(SDVM);
                return Json(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(false);
            }

        }
        [HttpGet]
        public IActionResult GetEmployeeDetailsById(int EmployeeId)
        {
            try
            {
                EmployeeViewModel EVM = new EmployeeViewModel();
                if (EmployeeId > 0)
                {
                    EVM = _ps.GEtEmployeeDetailsById(EmployeeId);
                }
                return Json(EVM);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult ViewSalaryDetails(int EmployeeId)
        {
            try
            {
                EmployeeViewModel EVM = _ps.GetEmployeeSalaryDetailsById(EmployeeId);
                if (EVM.SalaryDetaillst.Count == 0)
                {
                    return Json(false);
                }
                ViewBag.EmployeeId = EmployeeId;
                return PartialView(EVM.SalaryDetaillst);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public IActionResult EditSalaryDetail(SalaryDetailVM SDVM)
        {
            try
            {
                _ps.EditSalaryDetail(SDVM);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public IActionResult DeleteSalaryDetail(int SalaryDetailId)
        {
            try
            {
                bool result = _ps.DeleteSalaryDetail(SalaryDetailId);
                return Json(result);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
    }
}
