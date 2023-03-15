using HRMS_Silicon.Filter;
using HRMS_Silicon.Helper;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDesignationService _designationService;
        private readonly IDepartmentService _departmentServive;

        public EmployeeController(IEmployeeService employeeService, IDesignationService designationService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _designationService = designationService;
            _departmentServive = departmentService;
        }
        public IActionResult Index(EmployeeFilter employeeFilter = null, int pageNumber = 1)
        {
            try
            {

                EmployeeViewModelDetails employeeViewModelDetails = new EmployeeViewModelDetails();
                employeeViewModelDetails.EmployeeViewModels = _employeeService.GetAll();

                if (!string.IsNullOrWhiteSpace(employeeFilter.EmployeeNumberForSearch))
                {
                    //  employeeViewModelDetails.EmployeeViewModels = employeeViewModelDetails.EmployeeViewModels.Where(a => a.EmployeeNumber.Contains(employeeFilter.EmployeeNumberForSearch)).ToList();

                    employeeViewModelDetails.EmployeeViewModels = (List<EmployeeViewModel>)employeeViewModelDetails.EmployeeViewModels.Where(a => a.EmployeeNumber == employeeFilter.EmployeeNumberForSearch).ToList();
                    List<EmployeeViewModel> templist = employeeViewModelDetails.EmployeeViewModels.Where(x => x.EmployeeNumber == employeeFilter.EmployeeNumberForSearch).ToList();

                }

                if (!string.IsNullOrWhiteSpace(employeeFilter.FullNameForSearch))
                {
                    employeeViewModelDetails.EmployeeViewModels = employeeViewModelDetails.EmployeeViewModels.Where(a => a.FullName.Contains(employeeFilter.FullNameForSearch)).ToList();
                }


                foreach (var item in employeeViewModelDetails.EmployeeViewModels)
                {
                    //var activeEmployee = employee.Where(x => x.RecStatus == 'A').ToList();
                   
                    item.DepartmentViewModel = _departmentServive.GetById(item.Department_Id.Value);
                    item.DesignationViewModel = _designationService.GetById(item.Designation_Id.Value);
                }
                employeeViewModelDetails.EmployeePagedList = PaginatedList<EmployeeViewModel>.Create(employeeViewModelDetails.EmployeeViewModels.AsQueryable(), pageNumber, 5);

                return View(employeeViewModelDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();


            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                List<DesignationViewModel> designationViewModel = new List<DesignationViewModel>();
                designationViewModel = _designationService.GetAll();
                ViewBag.EmpDesignation = new SelectList(designationViewModel, "Designation_id", "Designation_name");

                List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();
                var departmentFilter = _departmentServive.GetAll();
                departmentViewModels = departmentFilter.Where(x => x.Is_Active==true).ToList();
                ViewBag.EmpDepartment = new SelectList(departmentViewModels, "Department_id", "Department_name");

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModelDetails employeeViewModelDetails, IFormFile file)
        {
            try
            {
                //if (Request.Form.Files.Count > 0)
                //{

                //}

                _employeeService.save(employeeViewModelDetails.EmployeeViewModel);

                //AlertHelper.setMessage(this, "Employee  saved successfully.", messageType.success);

                //return RedirectToAction("Index");
                return Json(true);
            }
            catch (Exception ex)
            {
                //AlertHelper.setMessage(this, ex.Message, messageType.error);
                Console.WriteLine(ex.Message);
                return Json(false);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                EmployeeViewModel employeeViewModel = _employeeService.GetById(id);
                List<DesignationViewModel> designationViewModel = new List<DesignationViewModel>();
                designationViewModel = _designationService.GetAll();
                ViewBag.EmpDesignation = new SelectList(designationViewModel, "Designation_id", "Designation_name");

                List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();
                departmentViewModels = _departmentServive.GetAll();
                ViewBag.EmpDepartment = new SelectList(departmentViewModels, "Department_id", "Department_name");


                return View(employeeViewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();
            }
        }


        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {

                _employeeService.update(employeeViewModel);

                //AlertHelper.setMessage(this, "Employee  updated successfully.", messageType.success);

                //return RedirectToAction("Index");
                return Json(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //AlertHelper.setMessage(this, ex.Message, messageType.error);

                return Json(false);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {

                _employeeService.delete(id);
                //DeleteVM deleteVM = new() { id=id,message = "Success" };

                //AlertHelper.setMessage(this, "Employee deleted successfully.", messageType.success);
                return Json(true);
            }
            catch (Exception ex)
            {
                //DeleteVM deleteVM = new() { id = id, message = "Failed "+ex.Message };

                //AlertHelper.setMessage(this, "Employee deleted successfully.", messageType.success);
                Console.WriteLine(ex.Message);
                return Json(false);
            }

        }

        [HttpPost]
        public JsonResult ChangeEmployeeStatus(int id)
        {
            try
            {
                var result = _employeeService.ChangeEmployeeStatus(id);
                //AlertHelper.setMessage(this, "Employee's status changed successfully.", messageType.success);

                //string[] result = {

                //    id.ToString()
                //};

                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //AlertHelper.setMessage(this, ex.Message, messageType.error);
                return Json(false);
            }

        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            try
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                employeeViewModel = _employeeService.GetById(id);

                DesignationViewModel designationViewModel = new DesignationViewModel();
                var designation = _designationService.GetAll();
                foreach (var item in designation)
                {
                    var designationId = _designationService.GetById((int)employeeViewModel.Designation_Id);
                    employeeViewModel.DesignationViewModel.Designation_name = designationId.Designation_name;
                    
                }

                DepartmentViewModel departmentViewModel = new DepartmentViewModel();
                var department = _departmentServive.GetAll();

                foreach (var item in department)
                {
                    var name = _departmentServive.GetById((int)employeeViewModel.Department_Id);
                    employeeViewModel.DepartmentViewModel.Department_name = name.Department_name;
                }
                return View(employeeViewModel);

            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction("Index");
        }
    }
}
