using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMono.Models.Common;
using VehicleMono.Models.Common.Parameters;
using VehicleMono.Models.Parameters;

namespace VehicleMono.Models
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleMake>().To<VehicleMake>();
            Bind<IVehicleModel>().To<VehicleModel>();

            Bind<IPagingParameter>().To<PagingParameter>();

        }
    }
}
