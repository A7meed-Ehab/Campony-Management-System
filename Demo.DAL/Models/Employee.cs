using System;
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
        public Department Department { get; set; }
    }
}
