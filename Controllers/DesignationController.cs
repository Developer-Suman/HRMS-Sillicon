using HRMS_Silicon.Helper;
using HRMS_Silicon.Models;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }
        // GET: DesignationController
        public ActionResult Index(int pageNumber = 1)
        {
            try
            {
                DesignationIndexVM designationIndexVM = new();

                designationIndexVM.DesignationViewModel = new DesignationViewModel();

                designationIndexVM.DesignationViewModels = _designationService.GetAll();

                designationIndexVM.DesignationPagedList = PaginatedList<DesignationViewModel>.Create(designationIndexVM.DesignationViewModels.AsQueryable(), pageNumber, 5);

                return View(designationIndexVM);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET: DesignationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DesignationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesignationController/Create
        [HttpPost]
        public ActionResult Create(DesignationIndexVM model)
        {
            try
            {
                _designationService.save(model.DesignationViewModel);

                //AlertHelper.setMessage(this, "Designation  saved successfully.", messageType.success);

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

        // GET: DesignationController/Edit/5
        public ActionResult Edit(int id)
        {
            DesignationViewModel designation = _designationService.GetById(id);
            return PartialView(designation);
        }

        // POST: DesignationController/Edit/5
        [HttpPost]
        public ActionResult Edit(DesignationViewModel designationViewModel)
        {
            try
            {
                _designationService.update(designationViewModel);
                //AlertHelper.setMessage(this, "Designation  updated successfully.", messageType.success);

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


        //DesignationController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _designationService.delete(id);
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


    }
}
