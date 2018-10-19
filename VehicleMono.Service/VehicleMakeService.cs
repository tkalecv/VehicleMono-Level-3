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
    public class VehicleMakeService : IVehicleMakeService
    {
        public IVehicleMakeRepository repository { get; protected set; }

        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateVehicleMakeAsync(IVehicleMake make)
        {
           await repository.CreateVehicleMakeAsync(make);
        }

        public async Task DeleteVehicleMakeAsync(IVehicleMake make)
        {
            await repository.DeleteVehicleMakeAsync(make);
        }

        public async Task<IVehicleMake> FindVehicleMakeByIDAsync(int id)
        {
           return await repository.FindVehicleMakeByIDAsync(id);
        }

        public async Task<IEnumerable<IVehicleMake>> GetAllVehicleMakesAsync()
        {
           return await repository.GetAllVehicleMakesAsync();
        }

        public async Task UpdateVehicleMakeAsync(IVehicleMake make)
        {
            await repository.UpdateVehicleMakeAsync(make);
        }
    }
}
