using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VehicleMono.Models;
using VehicleMono.Service.Common;
using VehicleMono.WebAPI.ViewModels;

namespace VehicleMono.WebAPI.Controllers
{
    public class VehicleModelController : ApiController
    {
        public IVehicleModelService service { get; set; }


        public VehicleModelController(IVehicleModelService service)
        {
            this.service = service;

        }

        // GET: api/VehicleMake
        public async Task<IEnumerable<VehicleModelVM>> GetVehicleModel()
        {

            return AutoMapper.Mapper.Map<IEnumerable<VehicleModelVM>>(await service.GetAllVehicleModelsAsync());
        }


        // POST: api/VehicleMake
        [ResponseType(typeof(VehicleModelVM))]
        public async Task<IHttpActionResult> PostVehicleModel([FromBody]VehicleModelVM vModel)
        {
            await service.CreateVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(vModel));

            return CreatedAtRoute("DefaultApi", new { id = vModel.ID }, vModel);
        }

        // PUT: api/VehicleMake/5
        [ResponseType(typeof(VehicleModelVM))]
        public async Task<IHttpActionResult> PutVehicleModel(int id, [FromBody]VehicleModelVM vModel)
        {


            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var modelWithID = AutoMapper.Mapper.Map<VehicleMakeVM>(await service.FindVehicleModelByIDAsync(id));

            if (modelWithID != null)
            {
                modelWithID.Name = vModel.Name;
                modelWithID.Abrv = vModel.Abrv;

                await service.UpdateVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(modelWithID));

            }
            else
            {
                return NotFound();
            }


            return Ok();
        }

        // DELETE: api/VehicleMake/5
        [ResponseType(typeof(VehicleModelVM))]
        public async Task<IHttpActionResult> DeleteVehicleModel(int id)
        {
            var vModel = AutoMapper.Mapper.Map<VehicleMakeVM>(await service.FindVehicleModelByIDAsync(id));

            if (vModel == null)
            {
                return NotFound();
            }

            await service.DeleteVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(vModel));

            return Ok(vModel);
        }



    }
}
