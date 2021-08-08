using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace veg.Controllers.Resources
{
    public class MakeResource : KeyValuePairResource
    {
      
        
        public ICollection<KeyValuePairResource> Models { get; set; }
         
     

        public MakeResource()
        {
            Models = new Collection<KeyValuePairResource>();
        }
    }
}