using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using veg.Core.Models;

namespace veg.Controllers.Resources
{
   
    public class SaveVehicleResource
    {
        public int Id { get; set; }
       
        public int ModelID { get; set; }

        public bool IsRegistered { get; set; }
        [Required]
        public ContactResource Contact { get; set; }

        public ICollection<int> Features { get; set; }

        public SaveVehicleResource(){
            Features = new Collection<int>();
        }
    }
}