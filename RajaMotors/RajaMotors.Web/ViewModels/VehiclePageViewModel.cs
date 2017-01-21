using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RajaMotors.Web.ViewModels
{
    public class VehiclePageViewModel
    {
         public IEnumerable<VehicleViewModel> vehicleList { get; set; }

        public string FilterBy { get; set; }

        public IEnumerable<SelectListItem> SortBy { get; set; }

        public int ClientId { get; set; }

        public VehiclePageViewModel(string selectedFilter, string selectedSort)
        {
          
            SortBy = new SelectList(new[]{
                       new SelectListItem{ Text="Name", Value="Name"},
                       new SelectListItem{ Text="Date", Value="Date"}}, "Text", "Value", selectedSort);

        }
    }
}