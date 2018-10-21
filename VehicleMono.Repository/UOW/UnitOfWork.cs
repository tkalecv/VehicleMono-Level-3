using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLevel3;
using System.Transactions;

namespace VehicleMono.Repository.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        protected VehicleContext context { get; private set; }

        public UnitOfWork(VehicleContext _context)
        {
            if (_context == null)
            {
                throw new ArgumentNullException("context");
            }
            context = _context;
        }

        public Task<int> AddAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                context.Set<T>().Add(entity);
            }
            return Task.FromResult(1);
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await context.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = context.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                context.Set<T>().Attach(entity);
                context.Set<T>().Remove(entity);
            }
            return Task.FromResult(1);
        }

        public Task<int> DeleteAsync<T>(int ID) where T : class
        {
            var entity = context.Set<T>().Find(ID);
            if (entity == null)
            {
                return Task.FromResult(1);
            }
            return DeleteAsync<T>(entity);
        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                context.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

            return Task.FromResult(1);
        }

        public void Dispose()
        {
            context.Dispose();
        }


    }
}
