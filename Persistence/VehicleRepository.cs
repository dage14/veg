using veg.Core.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using veg.Core;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using veg.Extensions;
namespace veg.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegDbContext context;

        public VehicleRepository(VegDbContext context)
        {
            this.context = context;
            
        }
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true){
            if(!includeRelated)
            {
                return await context.Vehicles.FindAsync(id);
            }
            
            return await context.Vehicles
                .Include(v => v.Features)
                  .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);

        }

        public void Add(Vehicle vehicle){
            context.Vehicles.Add(vehicle);
        }

         public void Remove(Vehicle vehicle){
            context.Vehicles.Remove(vehicle);
        }

    /*    public async Task<IEnumerable<Vehicle>> GetVehicles(Filter filter){
          return await context.Vehicles
                .Include(v => v.Model)
                  .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .ToListAsync();
        }*/
        public async Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery queryObj){
         
         var result = new QueryResult<Vehicle>();

          var query =  context.Vehicles
                .Include(v => v.Model)
                  .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .AsQueryable(); 
         
            if(queryObj.MakeId.HasValue){
                query = query.Where(v => v.Model.MakeId == queryObj.MakeId.Value);
            }

            if(queryObj.ModelID.HasValue){
                query = query.Where(v => v.ModelID == queryObj.ModelID.Value);
            }
           // string str;
           // Expression<Func<Vehicle, object>> exp;
            //var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>();
           // columnsMap.Add("make", v => v.Model.Make.Name );

            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>(){
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name,
                ["contactName"] = v => v.ContactName,
                //["id"] = v => v.Id
            };
            query = query.ApplyOrdering( queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();
            query = query.ApplyPaging(queryObj);



            result.Items =  await query.ToListAsync();

            return result;

            //query = ApplyOrdering(queryObj, query, columnsMap);
            
            //if(queryObj.SortBy == "make")
                //query = (queryObj.IsSortAscending) ? query.OrderBy(v => v.Model.Make.Name) : query.OrderByDescending(v => v.Model.Make.Name);

           
        }
    
      /* private IQueryable<Vehicle> ApplyOrdering(VehicleQuery queryObj, IQueryable<Vehicle> query , Dictionary<string, Expression<Func<Vehicle, object>>> columnsMap){
           
           if(queryObj.IsSortAscending){
               return query = query.OrderBy(columnsMap[queryObj.SortBy]);
           }
                
            else
                {
                    return query = query.OrderByDescending(columnsMap[queryObj.SortBy]);
                }

        }*/

    }
}