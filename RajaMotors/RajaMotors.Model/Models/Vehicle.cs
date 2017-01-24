using System;
using System.Collections.Generic; 

namespace RajaMotors.Model.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleModelNumber { get; set; }
        public DateTime VehicletDateAdded { get; set; }
        public DateTime? VehicletDateModified { get; set; } 
        public bool VehicleIsActive { get; set; }

        public int ClientId{ get; set; }
        public virtual Client Client {get;set;}
        public virtual ICollection<Service> services { get; set;}
        public Vehicle()
        {
            VehicletDateAdded = System.DateTime.Now;
            VehicleIsActive = true;
        }
    }
}
