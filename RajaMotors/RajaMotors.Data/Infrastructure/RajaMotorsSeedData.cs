using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data.Infrastructure
{
    public class RajaMotorsSeedData : DropCreateDatabaseIfModelChanges<RajaMotorsEntities>
    {
        protected override void Seed(RajaMotorsEntities context)
        {
            Client cl = new Client()
            {
                ClientId = 1,
                ClientName = "aliabbas",
                ClientMobile = "9662428480",
                ClientDateAdded = System.DateTime.Now,
                ClientIsActive = true,
                ClientAddress = "B-28, Prerna Tution Class",
                ClientAddress1 = "Near Chittekhan Lane",
                ClientAddress2 = "Gendigate Road Vadodara-390 017"
            };
            Client clientTwo = new Client()
            {
                ClientId = 2,
                ClientName = "ali",
                ClientMobile = "9662428480",
                ClientAddress = "B-28, Prerna Tution Class",
                ClientAddress1 = "Near Chittekhan Lane",
                ClientAddress2 = "Gendigate Road Vadodara-390 017",
                ClientAddress3 = "NULL",
                ClientDateAdded = System.DateTime.Now.AddDays(-60),
                ClientDateModified = System.DateTime.Now.AddDays(-60),
                ClientIsActive = true
            };

            Client clientThree = new Client()
            {
                ClientId = 3,
                ClientName = "mariam",
                ClientMobile = "1234567890",
                ClientAddress = "nagpada",
                ClientAddress1 = "mumbai",
                ClientAddress2 = "Maharashtra",
                ClientAddress3 = "MH-12351",
                ClientDateAdded = System.DateTime.Now.AddDays(-60),
                ClientDateModified = System.DateTime.Now.AddDays(-60),
                ClientIsActive = true
            };

            Vehicle vehicle = new Vehicle
            {
                VehicleModelName = "Honda Activa",
                VehicleModelNumber = "GJ-6 BQ-3822",
                KilometersDriven = "60",
                VehicleChasisNumber = "abcd-ewtw-e-ewtwe-twe",
                Client = cl,
                VehicletDateAdded = System.DateTime.Now,
                ClientId = cl.ClientId
            };

            //1   Honda Activa    GJ - 6 BQ - 3822    2016 - 01 - 01 17:33:44.227 NULL    1   1
            //2   Scooty Pep  GJ - 1 AQ - 1212    2016 - 11 - 01 17:33:44.227 NULL    1   1
            //3   Bajaj Pulsar    GJ - 3 CV - 3623    2016 - 07 - 01 17:33:44.227 NULL    1   1
            //4   Mahindra Kido   GJ - 5 BQ - 41529   2016 - 08 - 15 17:33:44.227 NULL    1   2
            //5   Enfield ThunderBird GJ - 12 BQ - 1199   2016 - 09 - 20 17:33:44.227 NULL    1   2

            Vehicle firstVehicle = new Vehicle()
            {
                VehicleModelName = "Scooty Pep",
                VehicleModelNumber = "GJ - 1 AQ",
                Client = clientTwo,
                KilometersDriven = "10",
                VehicleChasisNumber = "tert-ewtw-ewet-dfht-twet",
                VehicletDateAdded = System.DateTime.Now.AddDays(30),
                ClientId = clientTwo.ClientId

            };

            Vehicle secondVehicle = new Vehicle()
            {
                VehicleModelName = "Mahindra Kido",
                VehicleModelNumber = "AQ - 1212",
                Client = clientTwo,
                KilometersDriven = "1032",
                VehicleChasisNumber = "abcd-etsd-wtew-fghj",
                VehicletDateAdded = System.DateTime.Now.AddDays(30),
                ClientId = clientTwo.ClientId

            };

            Vehicle thirdVehicle = new Vehicle()
            {
                VehicleModelName = "Bajaj Pulsar",
                VehicleModelNumber = "AQ - 1212",
                Client = clientTwo,
                KilometersDriven = "4364",
                VehicleChasisNumber = "abcd-etsd-wtew-6666",
                VehicletDateAdded = System.DateTime.Now.AddDays(30),
                ClientId = clientTwo.ClientId

            };

            Service service = new Service
            {
                ServiceDate = System.DateTime.Now,
                ServiceDateAdded = System.DateTime.Now,
                ServiceDueDate = System.DateTime.Now.AddDays(10),
                Vehicle = vehicle,
                VehicleId = vehicle.VehicleId
            };


            cl.Vehicles.Add(vehicle);
            vehicle.services.Add(service);

            clientTwo.Vehicles.Add(secondVehicle);
            clientThree.Vehicles.Add(thirdVehicle);

            context.Clients.Add(cl);
            context.Clients.Add(clientTwo);
            context.Clients.Add(clientThree);
            context.Vehicles.Add(vehicle);
            context.Services.Add(service);

            context.Commit();
        }
    }
}
