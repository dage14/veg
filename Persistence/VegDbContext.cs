using Microsoft.EntityFrameworkCore;
using veg.Core.Models;

namespace veg.Persistence
{
    public class VegDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Model> Models { get; set; }


        public VegDbContext(DbContextOptions<VegDbContext> options)
            : base(options)
        {
            //System.Configuration.ConfigurationManager
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder){
           modelBuilder.Entity<VehicleFeature>().HasKey(vf => 
                new { vf.VehicleId, vf.FeatureId });
       }
    }
}