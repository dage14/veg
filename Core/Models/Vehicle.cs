using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace veg.Core.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
       
        public int ModelID { get; set; }

        public Model Model { get; set; }

        public bool IsRegistered { get; set; }
        [Required]
        [StringLengthAttribute(255)]
        public string ContactName { get; set; } 

        [Required]
        [StringLengthAttribute(255)]
        public string ContactPhone { get; set; }

        
        [StringLengthAttribute(255)]
        public string ContactEmail { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<VehicleFeature> Features { get; set; }

        public Vehicle(){
            Features = new Collection<VehicleFeature>();
        }
    }
}