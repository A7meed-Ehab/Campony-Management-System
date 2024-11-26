using Demo.DAL.Data.Configurations;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfigurations());
            modelBuilder.Entity<Department>().HasData(
         new Department {Id=1, Code = "Code1", Name = "Name1", DateOfCreation = new DateTime(2023, 11, 26) },
         new Department { Id = 2, Code = "Code2", Name = "Name2", DateOfCreation = new DateTime(2023, 12, 1) },
         new Department { Id = 3, Code = "Code3", Name = "Name3", DateOfCreation = new DateTime(2023, 12, 15) }
     );
            //            modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
            //        Id = 1,
            //        Name = "Alice Johnson",
            //        PhoneNumber = "01012345678",
            //        Email = "alice.johnson@example.com",
            //        Address = "123 Main Street",
            //        HireDate = new DateTime(2021, 3, 15),
            //        Salary = 50000.00m,
            //        IsDeleted = false,
            //        DepartmentId = 10
            //    },
            //    new Employee
            //    {
            //        Id = 2,
            //        Name = "Bob Smith",
            //        PhoneNumber = "01198765432",
            //        Email = "bob.smith@example.com",
            //        Address = "456 Elm Street",
            //        HireDate = new DateTime(2022, 6, 10),
            //        Salary = 45000.00m,
            //        IsDeleted = false,
            //        DepartmentId = 10
            //    }
            //);
        }

    
    public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
