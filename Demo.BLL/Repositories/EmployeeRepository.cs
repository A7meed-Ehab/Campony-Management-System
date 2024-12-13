using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return _context.Employees.Where(E => E.Address.ToLower().Contains(address.ToLower()));

        }

       

    }
}
