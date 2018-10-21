using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMono.Models.Common;
using VehicleMono.Repository.Common;
using VehicleMono.Service.Common;

namespace VehicleMono.Service
{
    public class VehicleModelService : IVehicleModelService
    {

        public IVehicleModelRepository repository { get; protected set; }

        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.repository = repository;
        }


        public async Task CreateVehicleModelAsync(IVehicleModel model)
        {
           await repository.CreateVehicleModelAsync(model);
        }

        public async Task DeleteVehicleModelAsync(IVehicleModel model)
        {
            await repository.DeleteVehicleModelAsync(model);
        }

        public async Task<IVehicleModel> FindVehicleModelByIDAsync(int id)
        {
           return await repository.FindVehicleModelByIDAsync(id);
        }

        public async Task<IEnumerable<IVehicleModel>> GetAllVehicleModelsAsync()
        {
            return await repository.GetAllVehicleModelsAsync();
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel model)
        {
            await repository.UpdateVehicleModelAsync(model);
        }
    }
}
