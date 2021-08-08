using System.ComponentModel.DataAnnotations;
namespace veg.Core.Models
{
    public class Feature
    {
        public int Id { get; set; }
        
        [Required]
        [StringLengthAttribute(255)]
        public string Name { get; set; }
    }
}