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
    public class NoticeController : Controller
    {
        public INoticeService _ns;
        public NoticeController(INoticeService ns)
        {
            _ns = ns;
        }
        public IActionResult Index(int pageNumber = 1)
        {
            try
            {
                NoticeIndexViewModel noticeIndexVM = new();
                noticeIndexVM.Notice = new NoticeViewModel();

                noticeIndexVM.Notices = _ns.GetAll().OrderByDescending(x => x.NoticeDate).ToList();

                noticeIndexVM.NoticePagedList = PaginatedList<NoticeViewModel>.Create(noticeIndexVM.Notices.AsQueryable(), pageNumber, 5);

                return View(noticeIndexVM);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();
            }
        }
        [HttpPost]
        public IActionResult Create(NoticeIndexViewModel NIVM)
        {
            try
            {
                _ns.Save(NIVM.Notice);
                return Json(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(false);
            }

        }

        public IActionResult NoticeList(int pageNumber = 1)
        {
            NoticeIndexViewModel noticeIndexVM = new();
            noticeIndexVM.Notice = new NoticeViewModel();
            noticeIndexVM.Notices = _ns.GetAll().OrderByDescending(x => x.NoticeDate).ToList();
            noticeIndexVM.NoticePagedList = PaginatedList<NoticeViewModel>.Create(noticeIndexVM.Notices.AsQueryable(), pageNumber, 5);

            return PartialView("_Noticelist", noticeIndexVM);
        }
        [HttpPost]
        public ActionResult Delete(int NoticeId)
        {
            try
            {
                _ns.Delete(NoticeId);
                return Json(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);
            }
        }
        [HttpPost]
        public IActionResult ToogleStatus(int NoticeId)
        {
            try
            {
                _ns.ToogleStatus(NoticeId);
                return Json(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);
            }
        }
        [HttpGet]
        public IActionResult NoticePartial(int NoticeId)    
        {
            try
            {
                NoticeViewModel NVM = new NoticeViewModel();
                NVM = _ns.GetById(NoticeId);
                return PartialView(NVM);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
