using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RajaMotors.Web.ViewModels
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]

        public DateTime ServiceDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]

        public DateTime ServiceDueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]

        public DateTime ServiceDateAdded { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime? ServiceDateModified { get; set; } 
        public virtual Vehicle Vehicle { get; set; }
        public bool ServiceIsActive { get; set; }

    }
}