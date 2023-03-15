using HRMS_Silicon.Data;
using HRMS_Silicon.Helper;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HRMS_Silicon.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        // GET: DepartmentController
        public ActionResult Index(int pageNumber = 1)
        {
            DepartmentIndexVM departmentIndexVM = new();
            departmentIndexVM.DepartmentViewModel = new DepartmentViewModel();

            departmentIndexVM.DepartmentViewModels = _departmentService.GetAll();

            departmentIndexVM.DepartmentPagedList = PaginatedList<DepartmentViewModel>.Create(departmentIndexVM.DepartmentViewModels.AsQueryable(), pageNumber, 5);

            return View(departmentIndexVM);

        }


        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentIndexVM model)
        {
            try
            {
                _departmentService.save(model.DepartmentViewModel);
                //AlertHelper.setMessage(this, "Department Saved Successfully.", messageType.success);
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

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            DepartmentViewModel department = _departmentService.GetById(id);
            return PartialView(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel departmentViewModel)
        {
            try
            {
                _departmentService.update(departmentViewModel);

                return Json(true);
                //AlertHelper.setMessage(this, "Department Updated Successfully", messageType.success);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //    AlertHelper.setMessage(this, ex.Message, messageType.error);
                //    return View();
                Console.WriteLine(ex.Message);
                return Json(false);
            }
        }

     

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _departmentService.delete(id);
                //DeleteVM deleteVM = new() { id = id, message = "Success" };
                
                return Json(true);
            }
            catch (Exception ex)
            {
                //DeleteVM deleteVM = new() { id = id, message = "Failed " + ex.Message };
                Console.WriteLine(ex.Message);

                return Json(false);
            }
        }

        [HttpPost]
        public IActionResult ToogleStatus(int Department_Id)
        {
            try
            {
                //EmployeeViewModel obj = new EmployeeViewModel();
                //if(obj.DepartmentViewModel.Department_id != Department_Id)
                //{
                //    //_departmentService.ToogleStatus(Department_Id);
                //    return Json(false);

                //}
                var result = _departmentService.ToogleStatus(Department_Id);
                if(result == true)
                {
                    return Json(true);
                }

                return Json(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);
            }
        }


        //[HttpPost]
        //public JsonResult ChangeDepartmentStatus(int id)
        //{
        //    try
        //    {
        //        var result = _departmentService.ChangeDepartmentStatus(id);
        //        return Json(result);

        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return Json(false);
        //    }
        //}
    }
}
