using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMono.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIDAsync(int id);
        IQueryable<T> GetAllAsync();

        Task InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
