using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IEmployeeRepository EmployeeRepository { get ; private set; }
        public IDepartmentRepository DepartmentRepository { get ; private set; }
        public UnitOfWork(AppDbContext appDbContext)
        {
            this._context = appDbContext;
            EmployeeRepository = new EmployeeRepository(appDbContext);
            DepartmentRepository = new DepartmentRepository(appDbContext);
        }
        public int Complete()
        {
          return  _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
