using Ninject.Extensions.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLevel3.Entities;
using VehicleMono.Repository.Common;
using VehicleMono.Repository.UOW;

namespace VehicleMono.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IGenericRepository<VehicleMakeEntity>)).To(typeof(GenericRepository<VehicleMakeEntity>));
            Bind(typeof(IGenericRepository<VehicleModelEntity>)).To(typeof(GenericRepository<VehicleModelEntity>));

            Bind<IUnitOfWorkFactory>().ToFactory();

        }
    }
}
