﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLevel3
{
   public interface IVehicleContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry Entry<T>(T entity) where T : class;
        void SetModified<T>(T entity) where T : class;
    }
}
