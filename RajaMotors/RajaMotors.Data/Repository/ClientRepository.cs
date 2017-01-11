using RajaMotors.Data.Infrastructure;
using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data.Repository
{
    public class ClientRepository : RepositoryBase<Client>,IClientRepository
    {
        public ClientRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IEnumerable<Client> GetClientsByPage(int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            var skipGoals = noOfRecords * currentPage;

            var clients = this.GetMany(c => c.ClientIsActive == true);

            if (!string.IsNullOrEmpty(filterBy))
            {
                clients = clients.Where(c => c.ClientName.ToLower().Contains(filterBy.ToLower()));
            }


            //for sorting based on date and popularity
            clients = (sortBy == "Name") ? clients.OrderBy(c => c.ClientName) : clients;
            clients = (sortBy == "Date") ? clients.OrderBy(c => c.ClientDateAdded) : clients;

            clients = clients.Skip(skipGoals).Take(noOfRecords);

            return clients.ToList();

        }
    }

    public interface IClientRepository : IRepository<Client>
    {
        IEnumerable<Client> GetClientsByPage(int currentPage, int noOfRecords, string sortBy, string filterBy);
    }
}
