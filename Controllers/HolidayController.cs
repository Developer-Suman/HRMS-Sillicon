using HRMS_Silicon.Helper;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Controllers
{
    public class HolidayController : Controller
    {
        public IHolidayService _hs;
        public HolidayController(IHolidayService hs)
        {
            this._hs = hs;
        }
        public IActionResult Index(int pageNumber = 1)
        {
            try
            {
                HolidayIndexViewModel holidayIndexVM = new();
                holidayIndexVM.Holiday = new HolidayViewModel();

                holidayIndexVM.Holidays = _hs.GetAll().OrderByDescending(x=>x.HolidayDate).ToList();

                holidayIndexVM.HolidayPagedList = PaginatedList<HolidayViewModel>.Create(holidayIndexVM.Holidays.AsQueryable(), pageNumber, 5);

                return View(holidayIndexVM);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();
            }
        }

        public IActionResult Create(HolidayIndexViewModel HIVM)
        {
            try
            {
                _hs.Save(HIVM.Holiday);
                return Json(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(false);
            }

        }

        public IActionResult HolidayList(int pageNumber = 1)
        {
            HolidayIndexViewModel holidayIndexVM = new();
            holidayIndexVM.Holiday = new HolidayViewModel();
            holidayIndexVM.Holidays = _hs.GetAll().OrderByDescending(x => x.HolidayDate).ToList();
            holidayIndexVM.HolidayPagedList = PaginatedList<HolidayViewModel>.Create(holidayIndexVM.Holidays.AsQueryable(), pageNumber, 5);

            return PartialView("_Holidaylist", holidayIndexVM);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HolidayViewModel holiday = _hs.GetById(id);
            return PartialView(holiday);
        }
        [HttpPost]
        public ActionResult Edit(HolidayViewModel HVM)
        {
            try
            {
                _hs.Update(HVM);
                return Json(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Holiday_Id)
        {
            try
            {
                _hs.Delete(Holiday_Id);
                return Json(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);
            }
        }
    }
}
