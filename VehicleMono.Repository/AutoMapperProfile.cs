using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLevel3.Entities;
using VehicleMono.Models;
using VehicleMono.Models.Common;

namespace VehicleMono.Repository
{
   public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();

            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();

        }
    }
}
