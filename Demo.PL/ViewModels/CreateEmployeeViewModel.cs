using Demo.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class CreateEmployeeViewModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "Name must be More Than 3 characters.", MinimumLength = 3)]
        public  string Name { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [StringLength(30, ErrorMessage = "Address can't be greater than 200 characters.")]
        public string Address { get; set; }

        [Range(6000, double.MaxValue, ErrorMessage = "Salary must be greater then 6000$")]
        [Required]
        public decimal Salary { get; set; } = 6000;
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }

    }
}
