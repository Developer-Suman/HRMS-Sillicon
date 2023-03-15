using AutoMapper;
using HRMS_Silicon.Models;
using HRMS_Silicon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Automapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Designation, DesignationViewModel>().ReverseMap();
            CreateMap<Designation, DesignationIndexVM>().ReverseMap();

            CreateMap<Department, DepartmentIndexVM>().ReverseMap();
            CreateMap<Department, DepartmentViewModel>().ReverseMap();

            CreateMap<Employee, EmployeeViewModelDetails>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
          
            CreateMap<Leave, LeaveViewModelDetails>().ReverseMap();
            CreateMap<Leave, LeaveViewModel>().ReverseMap();  
            
            CreateMap<Attendence, AttendenceViewModelDetails>().ReverseMap();
            CreateMap<Attendence, AttendenceViewModel>().ReverseMap();

            CreateMap<ApplicationUser, ApplicationViewModel>().ReverseMap();

            CreateMap<Holiday, HolidayViewModel>().ReverseMap();
            CreateMap<Notice, NoticeViewModel>().ReverseMap();
            CreateMap<SalaryDetail, SalaryDetailVM>().ReverseMap();
            CreateMap<EmployeeSalaryDetail, EmployeeSalaryDetailVM>().ReverseMap();
        }
    }
}
