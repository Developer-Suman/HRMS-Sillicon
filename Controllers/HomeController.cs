using HRMS_Silicon.Models;
using HRMS_Silicon.Repository.RepoImplementation;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserActivityFilter _userActivityFilter;
        private readonly ILogger<HomeController> _logger;
        private readonly IHolidayService _holidayService;
        UnitOfWorkRepoImpl _uow;
        private readonly INoticeService _noticeService;

        private readonly IEmployeeService _employeeService;
        private readonly IDesignationService _designationService;
        public HomeController(ILogger<HomeController> logger, UnitOfWorkRepoImpl uow, IHolidayService holidayService, INoticeService noticeService, IEmployeeService employeeService, IDesignationService designationService, IUserActivityFilter userActivityFilter)
        {
            _logger = logger;
            _uow = uow;
            _holidayService = holidayService;
            _noticeService = noticeService;
            _employeeService = employeeService;
            _designationService = designationService;
            _userActivityFilter = userActivityFilter;
        }

        [Authorize]
        public IActionResult Index()
        {
            IndexViewModel IVM = new IndexViewModel();

            IVM.holidaylst = _holidayService.GetAll().Where(x => x.HolidayDate >= DateTime.Now).OrderBy(x => x.HolidayDate).ToList();
            IVM.noticelst = _noticeService.GetAll().Where(x => x.NoticeDate >= DateTime.Now.Date && x.isActive == true).OrderBy(x => x.NoticeDate).ToList();
            IVM.totalemployeelst = _employeeService.GetAll().ToList();
            IVM.totaldesignationlst = _designationService.GetAll().ToList();
            List<UserActivity> myModels = _userActivityFilter.GetAll();
            return View(IVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult GetCurrentUsersFullname(string Id)
        //{
        //    string fullname = "";
        //    fullname = _employeeService.GetFullnameByUserId(Id);
        //    return Json(fullname);
        //}
    }
}
