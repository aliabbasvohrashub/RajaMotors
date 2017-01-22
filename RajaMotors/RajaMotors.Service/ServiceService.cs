using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RajaMotors.Model.Models;
using RajaMotors.Data.Repository;
using RajaMotors.Data.Infrastructure;

namespace RajaMotors.Service
{
    public interface IServiceService
    {
        IEnumerable<RajaMotors.Model.Models.Service> GetServices();
        RajaMotors.Model.Models.Service GetServiceById(long Id);
        IEnumerable<RajaMotors.Model.Models.Service> GetService(IEnumerable<int> serviceIds);
        IEnumerable<RajaMotors.Model.Models.Service> SearchService(String serviceName);
        IEnumerable<RajaMotors.Model.Models.Service> GetServiceByPage(int clientId, int vehicleId, int currentPage, int noOfRecords, string sortBy, string filterBy);

        RajaMotors.Model.Models.Service Update(RajaMotors.Model.Models.Service service);
        RajaMotors.Model.Models.Service Delete(RajaMotors.Model.Models.Service service);

        RajaMotors.Model.Models.Service Add(RajaMotors.Model.Models.Service service);
        int serviceCount(int vehicleId);
        void SaveService();
    }

    public class ServiceService : IServiceService  
    {
        private readonly IClientRepository clientRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IServiceRepository serviceRepository;
        private readonly IUnitOfWork unitOfWork;
        public ServiceService(IClientRepository clientRepository, IVehicleRepository vehicleRepository, IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            this.clientRepository = clientRepository;
            this.vehicleRepository = vehicleRepository;
            this.serviceRepository = serviceRepository;
            this.unitOfWork = unitOfWork;
        }

        public Model.Models.Service Delete(Model.Models.Service service)
        {
            serviceRepository.Delete(service);
            SaveService();
            return service;
        }

        public IEnumerable<Model.Models.Service> GetService(IEnumerable<int> serviceIds)
        {
            List<Model.Models.Service> services = new List<Model.Models.Service>();
            foreach (int serviceid in serviceIds)
            {
                services.Add(serviceRepository.GetById(serviceid));
            }
            return services;

        } 
        public Model.Models.Service GetServiceById(long Id)
        {
            var service = serviceRepository.GetById(Id);
            return service;
        }

        public IEnumerable<Model.Models.Service> GetServices()
        {
            var services = serviceRepository.GetAll();
            return services;
        }

        public IEnumerable<Model.Models.Service> GetServiceByPage(int clientId, int vehicleId, int currentPage, int noOfRecords, string sortBy,
            string filterBy)
        {
            return serviceRepository.GetSericeByPage(clientId, vehicleId, currentPage, noOfRecords, sortBy, filterBy);
        }

        public Model.Models.Service Update(Model.Models.Service service)
        {
            serviceRepository.Update(service);
            SaveService();
            return service;
        }

        public int serviceCount(int vehicleId)
        {
            return serviceRepository.GetMany(x => x.Vehicle.VehicleId == vehicleId).Count();
        }

        public void SaveService()
        {
            unitOfWork.Commit();
        }

        public Model.Models.Service Add(Model.Models.Service service)
        {
            serviceRepository.Add(service);
            SaveService();
            return service;
        }

        public IEnumerable<Model.Models.Service> SearchService(string serviceName)
        {
            return serviceRepository.GetMany(x => x.Vehicle.VehicleModelNumber.Contains(serviceName));
        }
    }
}
