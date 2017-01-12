using System;
using System.Collections.Generic; 

namespace RajaMotors.Model.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientMobile { get; set; } 
        public string ClientAddress { get; set; }
        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; } 
        public string ClientAddress3 { get; set; }
        public DateTime ClientDateAdded { get; set; }
        public DateTime? ClientDateModified { get; set; } 
        public bool ClientIsActive { get; set; } 
        public virtual ICollection<Vehicle> Vehicles { get; set; } 
        public Client()
        {
            ClientDateAdded = System.DateTime.Now;
            ClientIsActive = true;
        }
    }
}
