﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee :  BaseModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImageName { get; set; }
        public DateTime HireDate { get; set; }=DateTime.Now;
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? DepartmentId { get; set; }
        //[ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
