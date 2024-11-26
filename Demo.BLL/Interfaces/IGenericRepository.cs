using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAllAsync(params string[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(T model);
    }
}
