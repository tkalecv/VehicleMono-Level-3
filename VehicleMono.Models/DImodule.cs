using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMono.Models.Common;

namespace VehicleMono.Models
{
    class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleMake>().To<VehicleMake>();
            Bind<IVehicleModel>().To<VehicleModel>();

        }
    }
}
