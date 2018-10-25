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
using System.Web.Http.Cors;

namespace VehicleMono.WebAPI.Controllers
{
    //Connect to Angular
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleMakeController : ApiController
    {
        public IVehicleMakeService service { get; set; }


        public VehicleMakeController(IVehicleMakeService service)
        {
            this.service = service;

        }
        // GET: api/VehicleMake
        public async Task<IEnumerable<VehicleMakeVM>> GetVehicleMake()
        {

            return AutoMapper.Mapper.Map<IEnumerable<VehicleMakeVM>>(await service.GetAllVehicleMakesAsync());
        }


        // POST: api/VehicleMake
        [ResponseType(typeof(VehicleMakeVM))]
        public async Task<IHttpActionResult> PostVehicleMake([FromBody]VehicleMakeVM make)
        {
            await service.CreateVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMake>(make));

            return  CreatedAtRoute("DefaultApi", new { id = make.ID }, make);
        }

        // PUT: api/VehicleMake/5
        [ResponseType(typeof(VehicleMakeVM))]
        public async Task<IHttpActionResult> PutVehicleMake(int id, [FromBody]VehicleMakeVM make)
        {


            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var makeWithID = AutoMapper.Mapper.Map<VehicleMakeVM>(await service.FindVehicleMakeByIDAsync(id));

            if (makeWithID != null)
            {
                makeWithID.Name = make.Name;
                makeWithID.Abrv = make.Abrv;

                await service.UpdateVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMake>(makeWithID));

            }
            else
            {
                return NotFound();
            }


            return Ok();
        }

        // DELETE: api/VehicleMake/5
        [ResponseType(typeof(VehicleMakeVM))]
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


    }
}
