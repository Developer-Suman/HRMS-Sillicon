using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using HRMS_Silicon.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HRMS_Silicon.Data;

namespace HRMS_Silicon.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        ApplicationDbContext _db;

        public LoginModel(SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "UserName/Email")]
            //[EmailAddress]
            public string UserNameOrEmail { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true


                //var user = await _userManager.FindByEmailAsync(Input.Email);

                var user = await _userManager.FindByNameAsync(Input.UserNameOrEmail) ?? await _userManager.FindByEmailAsync(Input.UserNameOrEmail);



                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt. Please Recheck UserName/Email, Password and Retry.");
                    return Page();
                }


                var result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //Auto Implement the Salary for Today Date
                    ImplementSalaryForCurrentDate();

                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt. Please Recheck UserName/Email, Password and Retry.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        //Auto check the salaryStatus if the Implementdation Date is Equals with the Current Date
        public void ImplementSalaryForCurrentDate()
        {
            DateTime FilterDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            List<SalaryDetail> salaryDetaillst = _db.salaryDetails.Where(x => x.SalaryImplementingDate >= FilterDate && x.SalaryImplementingDate < FilterDate.AddDays(1) && x.SalaryStatus == false).ToList();
            if (salaryDetaillst.Count != 0)
            {
                foreach (var item in salaryDetaillst)
                {
                    EmployeeSalaryDetail ESD = _db.EmployeeSalaryDetails.Where(x => x.SalaryDetailId == item.SalaryDetailId).FirstOrDefault();
                    if (ESD!=null)
                    {
                        List<EmployeeSalaryDetail> ESDlst = _db.EmployeeSalaryDetails.Where(x => x.Employee_id == ESD.Employee_id).ToList();
                        if (ESDlst.Count != 0)
                        {
                            foreach (var detail in ESDlst)
                            {
                                SalaryDetail salaryDetail = _db.salaryDetails.Find(detail.SalaryDetailId);
                                if (salaryDetail != null)
                                {
                                    if (salaryDetail.SalaryImplementingDate >= FilterDate && salaryDetail.SalaryImplementingDate < FilterDate.AddDays(1))
                                    {
                                        salaryDetail.SalaryStatus = true;
                                    }
                                    else
                                    {
                                        salaryDetail.SalaryStatus = false;
                                    }
                                    _db.salaryDetails.Update(salaryDetail);
                                    _db.SaveChanges();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
