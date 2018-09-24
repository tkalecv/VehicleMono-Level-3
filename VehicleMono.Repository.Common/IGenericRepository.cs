using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMono.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByID(int id);
        IQueryable<T> GetAll();

        Task Insert(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
