using RajaMotors.Data.Infrastructure;
using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            var services =
                this.GetMany(s => s.ServiceIsActive == true)
                    .Where(s => s.Vehicle.ClientId == clientId && s.Vehicle.VehicleId == vehicleId);

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

        public IEnumerable<Service> AllServicesDue()
        {
            var vehiclesWithLatestServiceDates =
                GetAll().GroupBy(x => x.VehicleId).Select(g => new
                {
                    vehicleId = g.Key,
                    lastServiceDate = g.Max(x => x.ServiceDate),
                    serviceId = g.OrderByDescending(x => x.ServiceDate)
                        .Select(x => x.ServiceId)
                        .FirstOrDefault()
                    //,serviceIdold = g
                    //    .Where(x => x.ServiceDate == g.Max(xx => xx.ServiceDate))
                    //    .Select(x => x.ServiceId).FirstOrDefault()
                });

            var servicedVehiclesHavingServiceDue =
                GetAll()
                    .Where
                    (
                        xx =>
                            vehiclesWithLatestServiceDates
                                .Select(x => x.serviceId)
                                .Contains(xx.ServiceId)
                            &&
                            xx.ServiceDate < System.DateTime.Now.AddDays(-90)
                    ).OrderBy(x => x.VehicleId);

            return servicedVehiclesHavingServiceDue;
        }
    }
}

public interface IServiceRepository : IRepository<Service>
{
    IEnumerable<Service> GetSericeByPage(int clientId, int vehicleId, int currentPage, int noOfRecords, string sortBy, string filterBy);
    IEnumerable<Service> AllServicesDue();

}
}
