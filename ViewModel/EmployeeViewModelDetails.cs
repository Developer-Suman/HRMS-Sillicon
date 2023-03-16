using HRMS_Silicon.Enum;
using HRMS_Silicon.Models;
using Microsoft.AspNetCore.Http;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class EmployeeViewModelDetails
    {
        public PaginatedList<EmployeeViewModel> EmployeePagedList { get; set; }
        public List<EmployeeViewModel> EmployeeViewModels { get; set; }
        public EmployeeViewModel EmployeeViewModel { get; set; }
        public SalaryDetailVM salaryDetail { get; set; }   

    }
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            DesignationViewModel = new DesignationViewModel();
            DepartmentViewModel = new DepartmentViewModel();
          
            
            //DepartmentViewModel = new DepartmentViewModel();
            EmployeeSalaryDetails = new List<EmployeeSalaryDetailVM>();
            SalaryDetaillst = new List<SalaryDetailVM>();
        }
        public int Employee_Id { get; set; }
        public int? Department_Id { get; set; }
        public List<Department> DepartmentModels { get; set; }


        [Display(Name = "Department Name")]
        public DepartmentViewModel DepartmentViewModel { get; set; }

        public int? Designation_Id { get; set; }
        public List<Designation> DesignationModels { get; set; }


        [Display(Name = "Designation Name")]
        public DesignationViewModel DesignationViewModel { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string First_name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => First_name + " " + Last_Name;

        [Required]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }


        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact_1 { get; set; }
        public string Contact_2 { get; set; }
        public MaritalStatusEnum Marital_status { get; set; }


        [Display(Name = "Gender")]
        public GenderEnum GenderEnum { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; } = DateTime.Now;


        [DataType(DataType.Date)]

        public DateTime Joining_date { get; set; } = DateTime.Now;  


        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public IFormFile File { get; set; }
        public bool Is_Active { get; set; } = true;
        public List<EmployeeSalaryDetailVM> EmployeeSalaryDetails { get; set; }

        public List<SalaryDetailVM> SalaryDetaillst { get; set; }       
    }
}
