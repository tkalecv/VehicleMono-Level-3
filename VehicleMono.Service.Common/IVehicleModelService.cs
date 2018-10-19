using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMono.Models.Common;

namespace VehicleMono.Service.Common
{
   public interface IVehicleModelService
    {
        Task CreateVehicleModelAsync(IVehicleModel model);
        Task DeleteVehicleModelAsync(IVehicleModel model);
        Task UpdateVehicleModelAsync(IVehicleModel model);

        Task<IVehicleModel> FindVehicleModelByIDAsync(int id);

        Task<IEnumerable<IVehicleModel>> GetAllVehicleModelsAsync();

    }
}
