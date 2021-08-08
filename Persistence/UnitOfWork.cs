using System.Threading.Tasks;
using veg.Core;
namespace veg.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
     
        private readonly VegDbContext context;
        public UnitOfWork(VegDbContext context)
        {
            this.context = context;
            
        }
        
        public async Task CompleteAsync(){
            await context.SaveChangesAsync();
        }
    
    }
}