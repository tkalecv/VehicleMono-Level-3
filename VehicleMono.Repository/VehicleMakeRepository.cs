using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using VehicleLevel3.Entities;
using VehicleMono.Models.Common;
using VehicleMono.Models.Common.Parameters;
using VehicleMono.Repository.Common;

namespace VehicleMono.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IGenericRepository<VehicleMakeEntity> repository { get; private set; }

        public VehicleMakeRepository(IGenericRepository<VehicleMakeEntity> repository)
        {
            this.repository = repository;
        }

        public async Task CreateVehicleMakeAsync(IVehicleMake make)
        {
            await repository.CreateAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(make));
        }

        public async Task DeleteVehicleMakeAsync(IVehicleMake make)
        {
            await repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(make));
        }

        public async Task UpdateVehicleMakeAsync(IVehicleMake make)
        {
            await repository.UpdateAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(make));
        }

        public async Task<IVehicleMake> FindVehicleMakeByIDAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleMake>(await repository.GetByIDAsync(id));
        }

        public async Task<IEnumerable<IVehicleMake>> GetAllVehicleMakesAsync()
        {
            IEnumerable<VehicleMakeEntity> makeList;
            makeList = await repository.GetAllAsync().ToListAsync();

            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(makeList);

            #region Paging
            ////Search
            //if (!String.IsNullOrEmpty(filterParameter.Search))
            //{
            //    makeList = await repository.GetAllAsync().Where(x => x.Name.ToUpper().StartsWith(filterParameter.Search.ToUpper())
            //    || x.Abrv.StartsWith(filterParameter.Search)).ToListAsync();


            //}
            //else
            //{
            //    makeList = await repository.GetAllAsync().ToListAsync();
            //}

            //IPagedList<VehicleMakeEntity> vehicleMakeList;

            ////Sorting
            //switch (sortingParameters.SortOrder)
            //{
            //    case "name_desc":
            //        vehicleMakeList = makeList.OrderByDescending(x => x.Name).ToPagedList(pagingParameter.Page, pagingParameter.PageSize);
            //        break;
            //    case "Abrv":
            //        vehicleMakeList = makeList.OrderBy(x => x.Abrv).ToPagedList(pagingParameter.Page, pagingParameter.PageSize);
            //        break;
            //    case "Abrv_desc":
            //        vehicleMakeList = makeList.OrderByDescending(x => x.Abrv).ToPagedList(pagingParameter.Page, pagingParameter.PageSize);
            //        break;
            //    default:
            //        vehicleMakeList = makeList.OrderBy(x => x.Name).ToPagedList(pagingParameter.Page, pagingParameter.PageSize);
            //        break;
            //}

            //return (AutoMapper.Mapper.Map<IPagedList<IVehicleMake>>(vehicleMakeList));
            #endregion  Paging
        }
    }
}
