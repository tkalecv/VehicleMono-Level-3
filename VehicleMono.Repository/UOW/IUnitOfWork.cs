﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMono.Repository.UOW
{
   public interface IUnitOfWork : IDisposable
    {
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> CommitAsync();
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(int ID) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
    }
}
