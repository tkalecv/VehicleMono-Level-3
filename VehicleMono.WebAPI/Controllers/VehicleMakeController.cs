using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VehicleLevel3;
using VehicleMono.Models;
using VehicleMono.Models.Common;
using VehicleMono.Service.Common;
using VehicleMono.WebAPI.ViewModels;

namespace VehicleMono.WebAPI.Controllers
{
    public class VehicleMakeController : ApiController
    {
        public IVehicleMakeService service { get; set; }

        private VehicleContext context { get; set; }

        public VehicleMakeController(IVehicleMakeService service, VehicleContext context)
        {
            this.service = service;

            this.context = context;
        }
        // GET: api/VehicleMake
        public async Task<IEnumerable<VehicleMakeVM>> GetVehicleMake()
        {
            return AutoMapper.Mapper.Map<IEnumerable<VehicleMakeVM>>(await service.GetAllVehicleMakesAsync());
        }

        //// GET: api/VehicleMake/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/VehicleMake
        [ResponseType(typeof(VehicleMakeVM))]
        public async Task<IHttpActionResult> PostVehicleMake([FromBody]VehicleMakeVM make)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.CreateVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMake>(make));

            return CreatedAtRoute("DefaultApi", new { id = make.ID }, make);
        }

        // PUT: api/VehicleMake/5
        public async Task<IHttpActionResult> PutVehicleMake(int id, [FromBody]VehicleMakeVM make)
        {
            if (id != make.ID)
            {
                return BadRequest();
            }

            try
            {
                await service.UpdateVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMake>(make));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleMakesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);

        }

        // DELETE: api/VehicleMake/5
        public async Task<IHttpActionResult> DeleteVehicleMake(int id)
        {
            var make = AutoMapper.Mapper.Map<VehicleMakeVM>(await service.FindVehicleMakeByIDAsync(id));

            if (make == null)
            {
                return NotFound();
            }

            await service.DeleteVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMake>(make));

            return Ok(make);
        }

        private bool VehicleMakesExists(int id)
        {
            return context.VehicleMakes.Count(x => x.ID == id) > 0;
        }

    }
}
