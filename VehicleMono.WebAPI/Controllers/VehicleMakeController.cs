using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VehicleMono.Models.Common;
using VehicleMono.Service.Common;
using VehicleMono.WebAPI.ViewModels;

namespace VehicleMono.WebAPI.Controllers
{
    public class VehicleMakeController : ApiController
    {
        public IVehicleMakeService service { get; set; }

        public VehicleMakeController(IVehicleMakeService service)
        {
            this.service = service;
        }
        // GET: api/VehicleMake
        public async Task<IEnumerable<VehicleMakeVM>> Get()
        {
            return AutoMapper.Mapper.Map<IEnumerable<VehicleMakeVM>>(await service.GetAllVehicleMakesAsync());
        }

        // GET: api/VehicleMake/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VehicleMake
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VehicleMake/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VehicleMake/5
        public void Delete(int id)
        {
        }
    }
}
