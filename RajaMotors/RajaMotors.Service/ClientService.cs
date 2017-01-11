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
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(long Id); 
        IEnumerable<Client> GetClients(IEnumerable<int> ClientIds);
        IEnumerable<Client> SearchClients(string clientName);

        IEnumerable<Client> GetClientByPage(int currentPage, int noOfRecords, string sortBy, string filterBy);
        IEnumerable<Client> SortAndSearchClients(string sortBy, string filterBy);
        Client Update(Client client);
        Client Delete(Client client);

        Client Add(Client Add);

        void SaveClient(); 
    }

    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IServiceRepository serviceRepository;
        private readonly IUnitOfWork unitOfWork;

        public ClientService(IClientRepository clientRepository, IVehicleRepository vehicleRepository, IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            this.clientRepository = clientRepository;
            this.vehicleRepository = vehicleRepository;
            this.serviceRepository = serviceRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IClientService Members

        public IEnumerable<Client> GetClients()
        {
            var clients = clientRepository.GetAll();
              
            return clients;
        }

        public Client GetClientById(long Id)
        { 
            var client = clientRepository.GetById(Id);
            return client;
        }
        public IEnumerable<Client> SortAndSearchClients(string sortBy,string filterBy)
        { 
            if (!string.IsNullOrEmpty(filterBy))
            {
              return clientRepository.GetMany(x => x.ClientName.Contains(sortBy)).OrderBy(x => x.ClientId);                 
            }
            else
            {
              return clientRepository.GetAll().OrderBy(x => x.ClientId);                 
            } 
        }
        public IEnumerable<Client> GetClients(IEnumerable<int> ClientIds)
        {
            List<Client> clients = new List<Client>();

            foreach (int ClientId in ClientIds)
            {
                var client = clientRepository.Get(c => c.ClientId == ClientId);
                clients.Add(client);
            }

            return clients;
        }

        public Client Delete(Client client)
        {
            try
            {
                clientRepository.Delete(client);
                SaveClient();
                return client;
            }
            catch (Exception ex)
            {
                throw ex.InnerException; 
            } 
        }


        public Client Add(Client client)
        {
            clientRepository.Add(client);
            SaveClient();
            return client;
        }
        public Client Update(Client client)
        {
            clientRepository.Update(client);
            SaveClient();
            return client;
        }

        public void SaveClient()
        {
            unitOfWork.Commit();             
        }

        public IEnumerable<Client> SearchClients(string clientName)
        {
            return clientRepository.GetMany(x => x.ClientName.ToLower().Contains(clientName));
        }

        public IEnumerable<Client> GetClientByPage(int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            return clientRepository.GetClientsByPage(currentPage, noOfRecords, sortBy, filterBy);
        } 

        #endregion
    }
}
