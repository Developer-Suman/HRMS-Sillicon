using Microsoft.AspNetCore.Mvc;

namespace HRMS_Silicon.Controllers
{
    public class TaskManagerController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        
        public IActionResult Dashboard()
        {
            return View();
        }
        
        public IActionResult AllTasks()
        {
            return View();
        }
        
        public IActionResult TasksProgress()
        {
            return View();
        }
        
        public IActionResult UpdateTasks()
        {
            return View();
        }
        
        public IActionResult Projects()
        {
            return View();
        }
        
    }
}
