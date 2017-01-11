using RajaMotors.Data.Infrastructure;
using RajaMotors.Data.Repository;
using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Service
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetVehicles();
        Vehicle GetVehicleById(long Id);
        IEnumerable<Vehicle> GetVehicles(IEnumerable<int> vehicleIds);
        IEnumerable<Vehicle> SearchVehicles(string modelName);
        Vehicle Update(Vehicle vehicle);
        Vehicle Delete(Vehicle vehicle);
        void SaveVehicle();
    }
    public class VehicleService : IVehicleService
    {
        private readonly IClientRepository clientRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IServiceRepository serviceRepository;
        private readonly IUnitOfWork unitOfWork;

        public VehicleService(IClientRepository clientRepository, IVehicleRepository vehicleRepository, IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            this.clientRepository = clientRepository;
            this.vehicleRepository = vehicleRepository;
            this.serviceRepository = serviceRepository;
            this.unitOfWork = unitOfWork;
        }
        public Vehicle Delete(Vehicle vehicle)
        {
            vehicleRepository.Delete(vehicle);
            SaveVehicle();
            return vehicle;
        }


        public Vehicle AddVehicle(Vehicle vehicle)
        {
            vehicleRepository.Add(vehicle);
            SaveVehicle();
            return vehicle;
        }
        public Vehicle GetVehicleById(long Id)
        {
            var vehicle = vehicleRepository.GetById(Id);
            return vehicle;
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            var vehicles = vehicleRepository.GetAll();
            return vehicles;
        }

        public IEnumerable<Vehicle> GetVehicles(IEnumerable<int> vehicleIds)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (int vehicleid in vehicleIds)
            {
                vehicles.Add(vehicleRepository.GetById(vehicleid)); 
            }
            return vehicles;
        } 

        public Vehicle Update(Vehicle vehicle)
        {
            vehicleRepository.Update(vehicle);
            SaveVehicle();
            return vehicle;
        }

         
        public void SaveVehicle()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<Vehicle> SearchVehicles(string modelName)
        {
            return vehicleRepository.GetMany(x => x.VehicleModelName.Contains(modelName));
        }
    }
}
