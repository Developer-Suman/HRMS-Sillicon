using HRMS_Silicon.Data;
using HRMS_Silicon.Filter;
using HRMS_Silicon.Helper;
using HRMS_Silicon.Service.ServiceInterface;
using HRMS_Silicon.ViewModel;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Controllers
{
    public class LeaveController : Controller
    {
        private ApplicationDbContext entities { get; }
        public IEmployeeService _employeeService { get; }
        public ILeaveService _leaveService { get; }

        public IEmailSender _emailSender { get; set; }

        public LeaveController(IEmployeeService employeeService, ILeaveService leaveService, IEmailSender emailSender, ApplicationDbContext context)
        {
            _employeeService = employeeService;
            _leaveService = leaveService;
            _emailSender = emailSender;
            entities = context;
        }
        public IActionResult Index(LeaveFilter leaveFilter, int pageNumber = 1)
        {

            try
            {
                //_emailSender.SendEmailAsync("1brajesh1gupta@gmail.com", "Leave Requested", "Test Message");

                //we will put everthing in below variable of leaveViewModelDetails to finally return
                LeaveViewModelDetails leaveViewModelDetails = new LeaveViewModelDetails();


                //this part is for search parameters to refresh in pagination
                #region Search Params
                leaveViewModelDetails.LeaveFilter = new LeaveFilter();

                if (leaveFilter != null)
                {
                    leaveViewModelDetails.LeaveFilter.Date_fromForSearch = leaveFilter.Date_fromForSearch;
                    leaveViewModelDetails.LeaveFilter.Date_toForSearch = leaveFilter.Date_toForSearch;
                    leaveViewModelDetails.LeaveFilter.EmployeeNameForSearch = leaveFilter.EmployeeNameForSearch;
                }

                #endregion

                #region filter region by search params

                List<LeaveViewModel> leavelistbyDate = new();
                List<LeaveViewModel> leaveViewModelsByEmployeeId = new();

                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("HRManager"))
                {
                    leaveViewModelDetails.LeaveViewModels = _leaveService.GetAll();
                }
                else
                {
                    var employeeid = _employeeService.GetByUsername(User.Identity.Name).EmployeeId;

                    leaveViewModelDetails.LeaveViewModels = _leaveService.GetByEmployeeId(Convert.ToInt32(employeeid));
                }


                foreach (var item in leaveViewModelDetails.LeaveViewModels)
                {
                    item.EmployeeViewModel = _employeeService.GetById(item.Employee_id);
                }


                foreach (var item in leaveViewModelDetails.LeaveViewModels)
                {
                    if (leaveFilter.Date_fromForSearch.Date < item.Date_to.Date)
                    {
                        if (leaveFilter.Date_fromForSearch.Date >= item.Date_from.Date)
                        {
                            leavelistbyDate.Add(item);

                        }
                        else if (leaveFilter.Date_fromForSearch.Date < item.Date_from.Date)
                        {
                            if (leaveFilter.Date_toForSearch.Date <= item.Date_to.Date)
                            {
                                if (leaveFilter.Date_toForSearch.Date >= item.Date_from.Date)
                                {
                                    leavelistbyDate.Add(item);

                                }
                            }
                            else
                            {
                                leavelistbyDate.Add(item);
                            }
                        }
                    }
                    else
                    {
                        if (leaveFilter.Date_fromForSearch.Date == item.Date_to.Date)
                        {
                            leavelistbyDate.Add(item);
                        }
                    }

                }

                //if (TempData["HoldSearch"] != TempData["HoldSearch"])
                //if (leaveFilter.Date_fromForSearch != leaveFilter.Date_toForSearch)
                //{
                //    foreach (var item in leaveViewModelDetails.LeaveViewModels)
                //    {
                //        if (leaveFilter.Date_fromForSearch <= item.Date_from && leaveFilter.Date_toForSearch >= item.Date_to)
                //        {
                //            leavelistbyDate.Add(item);
                //        }
                //    }
                //}

                //if (!string.IsNullOrWhiteSpace(leaveFilter.EmployeeNameForSearch))
                //{
                //    leaveViewModelDetails.LeaveViewModels = (List<LeaveViewModel>)leaveViewModelDetails.LeaveViewModels.Where(a => a.Date_from >= leaveFilter.Date_fromForSearch && a.Date_to <= leaveFilter.Date_toForSearch && a.EmployeeViewModel.FullName == leaveFilter.EmployeeNameForSearch).ToList();

                //    List<LeaveViewModel> leavelistbyDateAndName = leaveViewModelDetails.LeaveViewModels.Where(x => x.Date_from >= leaveFilter.Date_fromForSearch && x.Date_to <= leaveFilter.Date_toForSearch && x.EmployeeViewModel.FullName == leaveFilter.EmployeeNameForSearch).ToList();
                //}

                #endregion

                leaveViewModelDetails.LeavePaginatedVM = PaginatedList<LeaveViewModel>.Create(leavelistbyDate.AsQueryable(), pageNumber, 5);

                return View(leaveViewModelDetails);
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
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("HRManager"))
                {

                    List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
                    employeeViewModels = _employeeService.GetAll();
                    ViewBag.Employee = new SelectList(employeeViewModels, "Employee_Id", "FullName");
                }
                else
                {
                    var employeeid = _employeeService.GetByUsername(User.Identity.Name).EmployeeId;
                    var employeefullname = _employeeService.GetById(Convert.ToInt32(employeeid)).FullName;



                    ViewBag.Employee = employeeid;
                    ViewBag.EmployeeName = employeefullname;
                }

                return View();
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(LeaveViewModelDetails leaveViewModelDetails)
        {
            try
            {

                var savedLeave = _leaveService.Save(leaveViewModelDetails.LeaveVM);
                leaveViewModelDetails.LeaveVM.TotalDays = savedLeave.TotalDays;


                var employeeId = _employeeService.GetById(leaveViewModelDetails.LeaveVM.Employee_id);
                leaveViewModelDetails.LeaveVM.EmployeeViewModel.First_name = employeeId.FullName;




                string message = @"<!DOCTYPE html><body<div><h2>Leave Details</h2><div><table><tbody><tr><td><span >Employee Name</span></td><td>:</td><td><span>" + leaveViewModelDetails.LeaveVM.EmployeeViewModel.First_name.ToString() + "</span></td></tr><tr><td><span >Leave Date From</span></td><td>:</td><td><span>" + leaveViewModelDetails.LeaveVM.Date_from.ToShortDateString() + "</span> </td></tr><tr><td><span class>Leave Date To</span></td><td>:</td><td><span>" + leaveViewModelDetails.LeaveVM.Date_to.ToShortDateString() + "</span></td></tr><tr><td><span>Leave Applied On</span></td><td>:</td><td><span>" + DateTime.Now + "</span></td></tr><tr><td><span>Leave Type</span></td><td>:</td><td><span>" + leaveViewModelDetails.LeaveVM.LeaveTypeEnum + "</span></td></tr><tr><td><span>Total Days of Leave</span></td><td>:</td><td><span>" + leaveViewModelDetails.LeaveVM.TotalDays + "</span></td> </tr><tr><td> <span>Leave Reason</span></td><td>:</td> <td>   <span>" + leaveViewModelDetails.LeaveVM.Leave_reason + "</span> </td> </tr> </tbody> </table></div></div> </body></html>";



                _emailSender.SendEmailAsync("siliconsoftnepal@gmail.com", "Leave Request", message);

                //you must put company email below so that leave applied by employee copy will be sent to company.. 

                //_emailSender.SendEmailAsync("1brajesh1gupta@gmail.com", "Leave Request", message);

                //AlertHelper.setMessage(this, "Leave  saved successfully.", messageType.success);


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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                LeaveViewModel leaveViewModel = _leaveService.GetById(id);

                List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
                employeeViewModels = _employeeService.GetAll();
                ViewBag.Employee = new SelectList(employeeViewModels, "Employee_Id", "FullName");

                return View(leaveViewModel);
            }
            catch (Exception ex)
            {
                //AlertHelper.setMessage(this, ex.Message, messageType.error);
                Console.WriteLine(ex.Message);

                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(LeaveViewModel leaveViewModel)
        {
            try
            {
                _leaveService.Update(leaveViewModel);

                //AlertHelper.setMessage(this, "Leave updated successfully.", messageType.success);


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
                _leaveService.Delete(id);
                DeleteVM deleteVM = new() { id = id, message = "Success" };
                return Json(deleteVM);
            }
            catch (Exception ex)
            {
                DeleteVM deleteVM = new() { id = id, message = "Failed " + ex.Message };
                return Json(deleteVM);
            }

        }


        public JsonResult ChangeLeaveStatus(int id, string status)
        {
            try
            {
                var leaveViewModel = _leaveService.ChangeLeaveStatus(id, status);


                var employeeid = _leaveService.GetById(id).Employee_id;

                var employeEmail = _employeeService.GetById(Convert.ToInt32(employeeid)).Email;

                string email = employeEmail;


                if (status == "Approve")
                {

                    string message = @"<!DOCTYPE html><body<div><h3>Leave Approval Status </h3><div><table><tbody> <tr><td> <span>Leave Approval Status </span></td><td>:</td>  <td><span>Your Leave is Approved</span> </td> </tr> </tbody> </table></div></div> </body></html>";



                    _emailSender.SendEmailAsync(email, "Leave Request", message);

                }
                else if (status == "Reject")
                {

                    string message = @"<!DOCTYPE html><body<div><h3>Leave Approval Status </h3><div><table><tbody> <tr><td> <span>Leave Approval Status </span></td><td>:</td>  <td><span>Your Leave is Rejected. please Contact to the Admistration</span> </td> </tr> </tbody> </table></div></div> </body></html>";

                    _emailSender.SendEmailAsync(email, "Leave Request", message);

                }
                else if (status == "Pending")
                {

                    //string message = @"<!DOCTYPE html><body<div><h3>Leave Approval Status </h3><div><table><tbody> <tr><td> <span>Leave Approval Status </span></td><td>:</td>  <td><span>Your Leave is in Pending Status. Please Contact to the Admistration</span> </td> </tr> </tbody> </table></div></div> </body></html>";

                    //_emailSender.SendEmailAsync("1brajesh1gupta@gmail.com", "Leave Request", message);
                }

                string[] result = {
                    status,
                    id.ToString()
                };

                return Json(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Error");
            }
        }


        [HttpGet]
        public ActionResult Detail(int id)
        {
            try
            {
                LeaveViewModel leaveViewModel = new LeaveViewModel();
                leaveViewModel = _leaveService.GetById(id);

                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                var employee = _employeeService.GetAll();
                foreach (var item in employee)
                {
                    var EmployeeID = _employeeService.GetById((int)leaveViewModel.Employee_id);
                    leaveViewModel.EmployeeViewModel.First_name = EmployeeID.First_name;
                }
                return View(leaveViewModel);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction("Index");
        }
    }
}