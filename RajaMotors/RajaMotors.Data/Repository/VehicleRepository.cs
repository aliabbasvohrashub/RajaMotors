using RajaMotors.Data.Infrastructure;
using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data.Repository
{
    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IEnumerable<Vehicle> GetClientVehicles(int clientId)
        {
            var vehicle = this.GetAll().GroupBy(x => x.Client);
            var vehicles = this.GetMany(x => x.ClientId == clientId && x.VehicleIsActive == true && x.services.Count() == 0);
            return vehicles;
        }

        public IEnumerable<Vehicle> GetVehiclessByPage(int currentPage, int noOfRecords, string sortBy, string filterBy, int? clientId)
        {

            var xx = this.GetMany(x => x .VehicleId == x.services.Where(xxx => xxx.ServiceId == 1).FirstOrDefault().VehicleId);
            var v = this
                .GetAll()
                .GroupBy(x => x.ClientId)
                .Select(x=> new
                {
                    k = x.Key,
                    v = x.Count()
                });

            var vv = this
                .GetAll()
                .GroupBy(x => x.services.FirstOrDefault())
                .Select(x => new
                {
                    k = x.Key,
                    v = x.Count()
                });
            var skipGoals = noOfRecords * currentPage;
            var vehicles = this.GetMany(x => x.VehicleIsActive == true);

            if (clientId != null)
            {
                vehicles = vehicles.Where(x => x.ClientId == Convert.ToInt16(clientId));
            }
             

            if (!string.IsNullOrEmpty(filterBy))
            {
                vehicles = vehicles.Where(c => c.VehicleModelName.ToLower().Contains(filterBy.ToLower()));
            }


            //for sorting based on date and popularity
            vehicles = (sortBy == "Name") ? vehicles.OrderBy(c => c.VehicleModelName) : vehicles;
            vehicles = (sortBy == "Date") ? vehicles.OrderBy(c => c.VehicletDateAdded) : vehicles;

            vehicles = vehicles.Skip(skipGoals).Take(noOfRecords);
            return vehicles.ToList();
        }

        public IEnumerable<Vehicle> Vehicle_ServiceAnalysis(int? clientId)
        {
            //DataContext.Services.Where(x=>x.VehicleId == )
            //IEnumerable<Service> services = this.GetMany(x => x.VehicleId == clientId);
            IEnumerable<Vehicle> vehicles = this.GetMany(x => x.Client.ClientId == clientId);

            foreach (var vehicle in vehicles)
            {
                var xxx = DataContext.Services.Where(x => x.VehicleId == vehicle.VehicleId);
            }
           
            return vehicles; 
        }
    }

    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetClientVehicles(int clientId);
        IEnumerable<Vehicle> GetVehiclessByPage(int currentPage, int noOfRecords, string sortBy, string filterBy, int? clientId);
        IEnumerable<Vehicle> Vehicle_ServiceAnalysis(int? clientId);
    }
}
