using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Models
{

    public class ApplicationUser: IdentityUser
    {
        public override string UserName { get; set; }
        public string  Fullname { get; set; }
        public string  UserRoleId { get; set; }
        public IdentityRole UserRole { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee{ get; set; }
        public byte[] ProfilePicture { get; set; }

    }
}
