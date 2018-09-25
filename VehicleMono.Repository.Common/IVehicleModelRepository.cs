using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMono.Models.Common;
using VehicleMono.Models.Common.Parameters;

namespace VehicleMono.Repository.Common
{
   public interface IVehicleModelRepository
    {
        Task CreateVehicleModelAsync(IVehicleModel model);
        Task DeleteVehicleModelAsync(IVehicleModel model);
        Task UpdateVehicleModelAsync(IVehicleModel model);

        Task<IVehicleModel> FindVehicleModelByIDAsync(int id);
        Task<IPagedList<IVehicleModel>> GetAllVehicleModelsAsync(ISortingParameter sortingParameters, IFilteringParameter filterParameter, IPagingParameter pagingParameter);

    }
}
