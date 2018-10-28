using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLevel3.Entities;
using VehicleMono.Models.Common;
using VehicleMono.Repository.Common;

namespace VehicleMono.Repository
{
    class VehicleModelRepository: IVehicleModelRepository
    {
        protected IGenericRepository<VehicleModelEntity> repository { get; private set; }

        public VehicleModelRepository(IGenericRepository<VehicleModelEntity> repository)
        {
            this.repository = repository;
        }

        public async Task CreateVehicleModelAsync(IVehicleModel model)
        {
            await repository.CreateAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(model));

        }

        public async Task DeleteVehicleModelAsync(IVehicleModel model)
        {
            await repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(model));
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel model)
        {
            await repository.UpdateAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(model));
        }

        public async Task<IVehicleModel> FindVehicleModelByIDAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleModel>(await repository.GetByIDAsync(id));
        }

        public async Task<IEnumerable<IVehicleModel>> GetAllVehicleModelsAsync()
        {
            IEnumerable<VehicleModelEntity> modelList;
            modelList = await repository.GetAllAsync().ToListAsync();
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(modelList);
        }
    }
}
