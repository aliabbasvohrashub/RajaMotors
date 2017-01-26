using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace RajaMotors.Web.ViewModels
{
    public class ServicePageViewModel
    {
        public IEnumerable<ServiceViewModel> serviceList { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public string FilterBy { get; set; }

        public IEnumerable<VehicleViewModel> ListVehiclesServiceDue { get; set; }
        public IEnumerable<SelectListItem> SortBy { get; set; }

        public ServicePageViewModel(string selectedFilter, string selectedSort)
        {

            SortBy = new SelectList(new[]{
                       new SelectListItem{ Text="Name", Value="Name"},
                       new SelectListItem{ Text="Date", Value="Date"}}, "Text", "Value", selectedSort);

        }
    }
}