using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task AddAsync(T model)
        {
          await  _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T model)
        {
             _context.Remove(model);
           await  _context.SaveChangesAsync();
         }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] includeProperties)
        {
            var query = _context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query,
               (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();      
        }
    }
}
