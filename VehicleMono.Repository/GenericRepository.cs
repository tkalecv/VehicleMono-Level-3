using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLevel3;
using VehicleMono.Repository.Common;
using VehicleMono.Repository.UOW;

namespace VehicleMono.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected VehicleContext context { get; private set; }
        IUnitOfWorkFactory uowFactory;

        public GenericRepository(VehicleContext context, IUnitOfWorkFactory uowFactory)
        {
            this.context = context;
            this.uowFactory = uowFactory;
        }

        public async Task DeleteAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.DeleteAsync(entity);
            await unitOfWork.CommitAsync();
        }

        public IQueryable<T> GetAllAsync()
        {
            return context.Set<T>();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.AddAsync(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }
}
