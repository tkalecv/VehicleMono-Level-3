using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using VehicleLevel3.Entities;
using VehicleMono.Models.Common;
using VehicleMono.Models.Common.Parameters;
using VehicleMono.Repository.Common;
using AutoMapper;

namespace VehicleMono.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IGenericRepository<VehicleModelEntity> repository { get; private set; }

        public VehicleModelRepository(IGenericRepository<VehicleModelEntity> repository)
        {
            this.repository = repository;
        }

        public async Task CreateVehicleModelAsync(IVehicleModel model)
        {
            await repository.CreateAsync(Mapper.Map<VehicleModelEntity>(model));
        }

        public async Task DeleteVehicleModelAsync(IVehicleModel model)
        {
            await repository.DeleteAsync(Mapper.Map<VehicleModelEntity>(model));
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel model)
        {
            await repository.UpdateAsync(Mapper.Map<VehicleModelEntity>(model));
        }

        public async Task<IVehicleModel> FindVehicleModelByIDAsync(int id)
        {
            return Mapper.Map<IVehicleModel>(await repository.GetByIDAsync(id));
        }

        public Task<IEnumerable<IVehicleModel>> GetAllVehicleModelsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
