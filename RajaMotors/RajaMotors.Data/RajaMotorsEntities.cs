using Microsoft.AspNet.Identity.EntityFramework;
using RajaMotors.Data.Configuration;
using RajaMotors.Data.Infrastructure;
using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data
{
    public class RajaMotorsEntities : IdentityDbContext<ApplicationUser> 
    {
        public RajaMotorsEntities() : base("RajaMotorsEntities")
        {
           
        }

        public DbSet<Client> Clients {get;set;}
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Service> Services { get; set; }  

        public virtual void Commit()
        {
            base.SaveChanges();
        }  
          
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new RajaMotorsSeedData());
            base.OnModelCreating(modelBuilder);               
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new VehicleConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());

        }
    }
}
