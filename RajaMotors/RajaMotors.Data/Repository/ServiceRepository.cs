using RajaMotors.Data.Infrastructure;
using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data.Repository
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IEnumerable<Service> GetSericeByPage(int clientId, int vehicleId, int currentPage, int noOfRecords,
            string sortBy, string filterBy)
        {
            var skipGoals = noOfRecords * currentPage;

            var services = this.GetMany(s => s.ServiceIsActive == true).Where(s=>s.Vehicle.ClientId == clientId && s.Vehicle.VehicleId == vehicleId);

            if (!string.IsNullOrEmpty(filterBy))
            {
                services = services.Where(c => c.Vehicle.VehicleModelName.ToLower().Contains(filterBy.ToLower()));
            }


            //for sorting based on date and popularity
            services = (sortBy == "Name") ? services.OrderBy(c => c.Vehicle.VehicleModelName) : services;
            services = (sortBy == "Date") ? services.OrderBy(c => c.ServiceDateAdded) : services;

            services = services.Skip(skipGoals).Take(noOfRecords);

            return services.ToList();
             
        }
    }

    public interface IServiceRepository : IRepository<Service>
    {
        IEnumerable<Service> GetSericeByPage(int clientId , int vehicleId, int currentPage, int noOfRecords, string sortBy, string filterBy);

    }
}
