using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMono.Models.Common;
using VehicleMono.Models.Common.Parameters;

namespace VehicleMono.Service.Common
{
    public interface IVehicleMakeService
    {
        Task CreateVehicleMakeAsync(IVehicleMake make);
        Task DeleteVehicleMakeAsync(IVehicleMake make);
        Task UpdateVehicleMakeAsync(IVehicleMake make);

        Task<IVehicleMake> FindVehicleMakeByIDAsync(int id);

        Task<IEnumerable<IVehicleMake>> GetAllVehicleMakesAsync();

    }
}
