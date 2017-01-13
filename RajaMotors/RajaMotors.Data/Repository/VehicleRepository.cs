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
    }

    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetClientVehicles(int clientId);
    }
}
