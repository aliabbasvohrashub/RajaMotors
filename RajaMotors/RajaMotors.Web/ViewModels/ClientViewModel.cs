using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RajaMotors.Web.ViewModels
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage ="*")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "*")]
        public string ClientMobile { get; set; }
        [Required(ErrorMessage = "*")]
        public string ClientAddress { get; set; }
        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public string ClientDateAdded { get; set; }         
        public string ClientDateModified { get; set; }       
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<RajaMotors.Model.Models.Service> services { get; set; }

        public bool ClientIsActive { get; set; }
         
        public ApplicationUser User { get; set; }

        public ClientViewModel()
        {
            ClientDateAdded = System.DateTime.Now.ToString();
            ClientIsActive = true;
        }
    }
}