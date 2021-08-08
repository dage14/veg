using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using veg.Core.Models;
using veg.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using veg.Controllers.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
namespace veg.Controllers 
{
    public class FeaturesController : Controller
    {
        private readonly VegDbContext context;
        private readonly IMapper mapper;

        public FeaturesController(VegDbContext context, IMapper mapper){
             this.context = context;
             this.mapper = mapper;

        }

        [HttpGet("/api/features")]
        //[Authorize]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures(){

            var features = await context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }
    }
}