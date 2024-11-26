using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Department : BaseModel 
    {
        [Required(ErrorMessage ="Code Is Required!")]
        public string Code { get; set; }
        [Required(ErrorMessage ="Name is Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Date is Required!")]
        public DateTime DateOfCreation { get; set; }
        public ICollection<Employee> Employees = new HashSet<Employee>();
    }
}
