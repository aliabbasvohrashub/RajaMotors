using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RajaMotors.Web.ViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<ClientViewModel> Clients { get; set; }

        public IEnumerable<VehicleViewModel> Vehicles { get; set; }

        public string SearchText { get; set; }
    }
}