using AutoMapper;
using HRMS_Silicon.Automapper;
using HRMS_Silicon.Data;
using HRMS_Silicon.Helper;
using HRMS_Silicon.Models;
using HRMS_Silicon.Repository.RepoImplementation;
using HRMS_Silicon.Repository.RepoInterface;
using HRMS_Silicon.Service.ServiceImpl;
using HRMS_Silicon.Service.ServiceInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using NToastNotify.Libraries;

namespace HRMS_Silicon
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDatabaseDeveloperPageExceptionFilter();
            //services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            //services.AddControllersWithViews();

            var mapconfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainProfile>();
            }
            );


            // services.AddScoped(mapconfig.CreateMapper.RegisterMap());

            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             //.AddRoles<IdentityRole>()
             .AddDefaultUI()
             .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(UserActivityFilter));
            });
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddSession();





            //Repositories here
            services.AddScoped<UnitOfWorkRepoImpl>();
            //Service here
            services.AddScoped<IUserActivityFilter, UserActivityFilter>();
            services.AddScoped<IDesignationService, DesignationServiceImpl>();
            services.AddScoped<IDepartmentService, DepartmentServiceImpl>();
            services.AddScoped<IEmployeeService, EmployeeServiceImpl>();
            services.AddScoped<ILeaveService, LeaveServiceImpl>();
            services.AddScoped<IAttendenceService, AttendenceServiceImpl>();
            services.AddTransient<IHolidayService, HolidayService>();
            services.AddTransient<INoticeService, NoticeService>();
            services.AddTransient<IPayrollService, PayrollService>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseDeveloperExceptionPage();
            //app.UseMigrationsEndPoint();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
