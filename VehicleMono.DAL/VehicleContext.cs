using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLevel3.Entities;

namespace VehicleLevel3
{
   public class VehicleContext : DbContext/*, IVehicleContext*/
    {
        public VehicleContext() : base("name=VehicleContext")
        {

        }

        public DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMakeEntity>()
                .HasMany(x => x.VehicleModels)
                .WithOptional(x => x.VehicleMake)
                .HasForeignKey(x=> x.VehicleMakeID);
        }

        //public new IDbSet<T> Set<T>() where T : class
        //{
        //    return base.Set<T>();
        //}
        //public new DbEntityEntry Entry<T>(T entity) where T : class
        //{
        //    return base.Entry(entity);
        //}

        //public void SetModified<T>(T entity) where T : class
        //{
        //    Entry(entity).State = EntityState.Modified;
        //}

    }
}
