using Demo.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class CreateEmployeeVM
    {
        public string Name { get; set; }
        [RegularExpression("^01[0125][0 - 9]{8}$")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }
        public int? DepartmentId { get; set; }
        public  IEnumerable<Department> Departments { get; set; }
    }
}
