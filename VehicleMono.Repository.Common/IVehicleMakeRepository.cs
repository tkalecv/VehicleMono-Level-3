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
   public interface IVehicleMakeRepository
    {
        Task CreateVehicleMakeAsync(IVehicleMake make);
        Task DeleteVehicleMakeAsync(IVehicleMake make);
        Task UpdateVehicleMakeAsync(IVehicleMake make);

        Task<IVehicleMake> FindVehicleMakeByIDAsync(int id);
        Task<IPagedList<IVehicleMake>> GetAllVehicleMakesAsync(ISortingParameter sortingParameters, IFilteringParameter filterParameter, IPagingParameter pagingParameter);

    }
}
