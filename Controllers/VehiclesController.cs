using Microsoft.AspNetCore.Mvc;
using veg.Core.Models;
using veg.Controllers.Resources;
using AutoMapper;
using veg.Core;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace veg.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;

        }

   

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource){
             //throw new Exception();
              if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
      vehicle.LastUpdate = DateTime.Now;

      repository.Add(vehicle);
      await unitOfWork.CompleteAsync();

      vehicle = await repository.GetVehicle(vehicle.Id);

      var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

      return Ok(result);
        }

        [HttpPut("{id}")]// /api/vehicles/{id}
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource){
            
            if(!ModelState.IsValid)
            return BadRequest(ModelState);
            
            var vehicle = await repository.GetVehicle(id);
           

            if (vehicle == null)
            return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();
            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

             return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id, includeRelated: false);

            if (vehicle == null)
            return NotFound();

            repository.Remove(vehicle);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
            return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

    /*[HttpGet]
    public async Task<IEnumerable<VehicleResource>> GetVehicles()
    {
    
      var vehicles = await repository.GetVehicles();
    
     var result = mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);

      
       return result;
    }*/

    [HttpGet]
    public async Task<QueryResultResource<VehicleResource>> GetVehicles(VehicleQueryResource filterResource)
    {
        var filter = mapper.Map<VehicleQueryResource, VehicleQuery>(filterResource);
    
      var queryResult = await repository.GetVehicles(filter);

      return mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>(queryResult);
    
     //var result = mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(queryResult);

      
       //return result;
    }


    }
}