using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data.Infrastructure
{
    public class RajaMotorsSeedData : DropCreateDatabaseIfModelChanges<RajaMotorsEntities>
    { 
        protected override void Seed(RajaMotorsEntities context)
        {
            Client cl = new Client();
            cl.ClientName = "aliabbas";
            cl.ClientMobile = "9662428480";
            cl.ClientDateAdded = System.DateTime.Now;
            cl.ClientIsActive = true;
            cl.ClientAddress = "B-28, Prerna Tution Class";
            cl.ClientAddress1 = "Near Chittekhan Lane";
            cl.ClientAddress2 = "Gendigate Road Vadodara-390 017";

            context.Clients.Add(cl);

            Vehicle vehicle = new Vehicle();
            vehicle.VehicleModelName = "Honda Activa";
            vehicle.VehicleModelNumber = "GJ-6 BQ-3822";
            vehicle.Client = cl;
            vehicle.VehicletDateAdded = System.DateTime.Now;
            context.Vehicles.Add(vehicle);

            Service service = new Service();
            service.ServiceDate = System.DateTime.Now;
            service.ServiceDateAdded = System.DateTime.Now;
            service.ServiceDueDate = System.DateTime.Now.AddDays(10);
            service.Vehicle= vehicle;

            context.Services.Add(service);
            context.Commit();
        }
    }
}
