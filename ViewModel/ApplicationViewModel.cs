using Microsoft.AspNetCore.Identity;
using Project_Management.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.ViewModel
{
    public class ApplicationViewModel 
    {
        public  string UserName { get; set; }
        public string Fullname { get; set; }
        public string UserRoleId { get; set; }
        public IdentityRole UserRole { get; set; }
        public string EmployeeId { get; set; }

        public EmployeeViewModel EmployeeName { get; set; }

        
    }

}
