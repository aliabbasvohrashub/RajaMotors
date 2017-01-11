using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RajaMotors.Web.ViewModels
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleModelNumber { get; set; }
        public DateTime VehicletDateAdded { get; set; }
        public DateTime? VehicletDateModified { get; set; }
         
        public bool VehicleIsActive { get; set; }
        public virtual Client Client { get; set; }
        public virtual IEnumerable<RajaMotors.Model.Models.Service> Services { get; set; } 
        public VehicleViewModel()
        {
            VehicletDateAdded = System.DateTime.Now;
            VehicleIsActive = true;
        }
    }
}