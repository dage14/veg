using System.Threading.Tasks;
using System;
namespace veg.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}