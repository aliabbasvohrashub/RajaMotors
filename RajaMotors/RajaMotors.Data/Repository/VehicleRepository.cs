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
            var vehicles = this.GetMany(x => x.ClientId == clientId && x.VehicleIsActive == true);
            return vehicles;
        }

        public IEnumerable<Vehicle> GetVehiclessByPage(int currentPage, int noOfRecords, string sortBy, string filterBy, int? clientId)
        {
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
    }

    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetClientVehicles(int clientId);
        IEnumerable<Vehicle> GetVehiclessByPage(int currentPage, int noOfRecords, string sortBy, string filterBy, int? clientId);
    }
}
