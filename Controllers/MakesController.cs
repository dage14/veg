using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using veg.Core.Models;
using veg.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using veg.Controllers.Resources;

namespace veg.Controllers 
{
    public class MakesController : Controller
    {
        private readonly VegDbContext context;
        private readonly IMapper mapper;

        public MakesController(VegDbContext context, IMapper mapper){
             this.context = context;
             this.mapper = mapper;

        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes(){

            var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}