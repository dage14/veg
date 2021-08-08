using System.Threading.Tasks;
using veg.Core.Models;
using veg.Core;
using System.Collections.Generic;
namespace veg.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
        //Task<Vehicle> GetVehicles();
      
       Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery queryObj);
    }
}