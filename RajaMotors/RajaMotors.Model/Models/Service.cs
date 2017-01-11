using System;
using System.Collections.Generic; 

namespace RajaMotors.Model.Models
{
    public class Service
    {
        public int ServiceId { get; set; } 
        public DateTime ServiceDate { get; set; } 
        public DateTime ServiceDueDate { get; set; }
        public DateTime ServiceDateAdded { get; set; }
        public DateTime? ServiceDateModified { get; set; } 
        public virtual Vehicle Vehicle { get; set; } 
        public bool ServiceIsActive { get; set; }
        public Service()
        {
            ServiceDateAdded = System.DateTime.Now;
            ServiceIsActive = true;
        }
    }
}
