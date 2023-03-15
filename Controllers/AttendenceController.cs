using HRMS_Silicon.Helper;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Controllers
{
    public class AttendenceController : Controller
    {
        public IEmployeeService _employeeService { get; }
        public IAttendenceService _attendenceService { get; }

        public AttendenceController(IEmployeeService employeeService, IAttendenceService attendenceService)
        {
            _employeeService = employeeService;
            _attendenceService = attendenceService;
        }
        public IActionResult Index(int pageNumber = 1)
        {
            try
            {
                AttendenceViewModelDetails attendenceViewModelDetails = new AttendenceViewModelDetails();
                attendenceViewModelDetails.AttendenceViewModels = _attendenceService.GetAll();

                foreach (var item in attendenceViewModelDetails.AttendenceViewModels)
                {
                    item.EmployeeViewModel = _employeeService.GetById(item.Employee_id);
                }
                attendenceViewModelDetails.AttendencePaginatedVM = PaginatedList<AttendenceViewModel>.Create(attendenceViewModelDetails.AttendenceViewModels.AsQueryable(), pageNumber, 5);

                return View(attendenceViewModelDetails);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
                employeeViewModels = _employeeService.GetAll();
                ViewBag.Employee = new SelectList(employeeViewModels, "Employee_Id", "FullName");
                return View();
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(AttendenceViewModelDetails attendenceViewModelDetails)
        {
            try
            {
                _attendenceService.Save(attendenceViewModelDetails.AttendenceVM);
                AlertHelper.setMessage(this, "Attendence  saved successfully.", messageType.success);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();
            }
        }





    }
}
