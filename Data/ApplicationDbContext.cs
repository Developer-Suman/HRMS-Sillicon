using HRMS_Silicon.Models;
using HRMS_Silicon.Service.ServiceInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HRMS_Silicon.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("identity");


            //modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers", "Identity");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles", "Identity");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", "Identity");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "Identity");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "Identity");

            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", "Identity");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "Identity");

            // for creating application users table using name MyUsers.
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("MyUsers", "Identity");
            });

            this.Roles(modelBuilder);

            this.Users(modelBuilder);

            this.SeedUserRoles(modelBuilder);

            modelBuilder.Entity<EmployeeSalaryDetail>()
                .HasKey(x => new { x.Employee_id, x.SalaryDetailId });

            

        }
        //seeding for role 
        private new void Users(ModelBuilder modelBuilder)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                NormalizedUserName = "Admin".ToUpper(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                UserRoleId = "1"
            };
            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, "Admin@123");

            modelBuilder.Entity<ApplicationUser>().HasData(user);
        }

        private new void Roles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "2", Name = "Manager", ConcurrencyStamp = "2", NormalizedName = "Manager" },
                new IdentityRole() { Id = "3", Name = "Employee", ConcurrencyStamp = "3", NormalizedName = "Employee" },
                new IdentityRole() { Id = "4", Name = "HRManager", ConcurrencyStamp = "4", NormalizedName = "HRManager" }
                );
        }
        //admin enters using this.
        //private new void UserRoles(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(
        //        new IdentityUserRole<string>() { RoleId = "1", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
        //        );
        //}

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "1", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }

        public DbSet<UserActivity> userActivities { get; set; }
        public DbSet<Department> DepartmentModels { get; set; }
        public DbSet<Designation> DesignationModels { get; set; }
        public DbSet<Employee> EmployeeModels { get; set; }
        public DbSet<Resignation> ResignationModels { get; set; }
        public DbSet<Attendence> AttendenceModels { get; set; }
        public DbSet<Leave> LeaveModels { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<SalaryDetail> salaryDetails { get; set; }
        public DbSet<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; }



        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries())
        //    { 
        //        var entity = entry.Entity; 

        //        if(entry.State == EntityState.Deleted)
        //        {
        //            entry.State = EntityState.Modified;

        //            entity.GetType().GetProperty("RecStatus").SetValue(entity, 'D');
        //        }

        //    }
        //    return base.SaveChanges();
        //}









    }
}
