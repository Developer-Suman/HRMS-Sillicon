using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using HRMS_Silicon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using HRMS_Silicon.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using HRMS_Silicon.Service.ServiceInterface;

namespace HRMS_Silicon.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _applicationDbContext;
        public IEmployeeService _employeeService { get; }

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext applicationDbContext,
            IEmployeeService employeeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _applicationDbContext = applicationDbContext;
            _employeeService = employeeService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            //[Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            //[Required]
            //[Display(Name = "FullName")]
            //public string FullName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least 4 characters long with no whitespace.", MinimumLength = 4)]
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "User Role")]
            [ForeignKey("UserRole")]
            public string UserRoleId { get; set; }

            public List<SelectListItem> UserRole { get; set; }
            [Required]

            [Display(Name = "Employee Name")]
            public string Employee_id { get; set; }

            [ForeignKey("Employee_id")]
            public Employee EmployeeName { get; set; }
        }

        public async Task OnGetAsync(int id, ApplicationUser user, string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var userRoles = _applicationDbContext.Roles.ToList();
            var rolesList = new List<SelectListItem>();

            //var employeeid = _employeeService.GetById(id).Employee_Id;
            //var employeEmail = _employeeService.GetById(Convert.ToInt32(employeeid)).Email;

            //ViewData["email"] = employeEmail;


            foreach (var item in userRoles)
            {
                SelectListItem roleLists = new SelectListItem { Value = item.Id, Text = item.Name };
                rolesList.Add(roleLists);
            }
            ViewData["rolesList"] = rolesList;

            var employee = _applicationDbContext.EmployeeModels.ToList();

            var employeeList = new List<SelectListItem>();
            var emailList = new List<SelectListItem>();

            foreach (var item in employee)
            {
                var usercheck = _applicationDbContext.Users.Where(x => x.EmployeeId == item.Employee_id.ToString()).FirstOrDefault();

                if (usercheck == null)
                {
                    SelectListItem employeeLists = new SelectListItem { Value = Convert.ToString(item.Employee_id), Text = item.FullName };
                    employeeList.Add(employeeLists);
                }
            }
            ViewData["employeeList"] = employeeList;

            foreach (var item in employee)
            {
                SelectListItem emailLists = new SelectListItem { Value = Convert.ToString(item.Employee_id), Text = item.Email };
                emailList.Add(emailLists);

            }
            ViewData["emailList"] = emailList;


        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                int empId = Convert.ToInt32(Input.Employee_id);
                var employee = _applicationDbContext.EmployeeModels.Where(x => x.Employee_id == empId).FirstOrDefault();
                
                var user = new ApplicationUser
                {
                    UserName = Input.UserName,
                    Email = employee.Email,
                    UserRoleId = Input.UserRoleId,
                    EmployeeId = Input.Employee_id,
                    Employee = employee
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (user.UserRoleId == "1")
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
                }
                else if (user.UserRoleId == "2")
                {
                    await _userManager.AddToRoleAsync(user, "Manager");
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Manager"));

                }
                else if (user.UserRoleId == "3")
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Employee"));

                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "HRManager");
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "HRManager"));

                }

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
