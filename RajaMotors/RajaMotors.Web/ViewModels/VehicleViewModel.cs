using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RajaMotors.Web.ViewModels
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "*")]
        public string VehicleModelName { get; set; }
        [Required(ErrorMessage = "*")]
        public string VehicleModelNumber { get; set; }
        [Required(ErrorMessage = "*")]
        public string VehicleSerialNumber { get; set; }
        [Required(ErrorMessage = "*")]
        public string VehicleChasisNumber { get; set; }
        public string KilometersDriven { get; set; }
        public DateTime VehicletDateAdded { get; set; }
        public DateTime? VehicletDateModified { get; set; }
        public bool VehicleIsActive { get; set; }
        [Required(ErrorMessage = "*")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int serviceCount { get; set; }
        public virtual IEnumerable<RajaMotors.Model.Models.Service> Services { get; set; }
        public VehicleViewModel()
        {
            VehicletDateAdded = System.DateTime.Now;
            VehicleIsActive = true;
        }
    }
}