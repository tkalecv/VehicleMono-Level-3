using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using VehicleMono.Models;
using VehicleMono.Models.Common.Parameters;
using VehicleMono.Models.Parameters;
using VehicleMono.Service.Common;
using VehicleMono.WebAPI.ViewModels;

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
        [HttpGet]
        public async Task<IEnumerable<VehicleMakeVM>> GetVehicleMake([FromUri]IPagingParameter pagingParameter)
        {
            var makeList = AutoMapper.Mapper.Map<IEnumerable<VehicleMakeVM>>(await service.GetAllVehicleMakesAsync());

            // Get's Number of Rows Count   
            int count = makeList.Count();

            // Parameter is passed and if it is null then it default Value will be pageNumber:1  
            int CurrentPage = pagingParameter.pageNumber;

            // Parameter is passed and if it is null then it default Value will be pageSize:20
            int PageSize = pagingParameter.pageSize;

            // Display TotalCount of VehicleMake to User
            int TotalCount = count;

            // Calculating Totalpage by Dividing (Number of Records / Pagesize) 
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            // Returns List of VehicleMake after applying Paging  
            var vMake = makeList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).AsQueryable(); //tolist

            // if CurrentPage is greater than 1 it has previousPage
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage it has nextPage
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // Object which we are going to send in header   
            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };

            // Setting Header
            HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));

            return vMake;
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
