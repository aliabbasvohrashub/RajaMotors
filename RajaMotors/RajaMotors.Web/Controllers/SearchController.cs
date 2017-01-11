using AutoMapper;
using Microsoft.AspNet.Identity;
using RajaMotors.Model.Models;
using RajaMotors.Service;
using RajaMotors.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RajaMotors.Web.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly IClientService clientService;
        private readonly IVehicleService vehicleService;
        private readonly IServiceService serviceService;
        private readonly UserManager<ApplicationUser> UserManager;

        public SearchController(IClientService clientService, IVehicleService vehicleService, IServiceService serviceService, UserManager<ApplicationUser> userManager)
        {
            this.clientService = clientService;
            this.vehicleService = vehicleService;
            this.serviceService = serviceService;
            UserManager = userManager;
        }
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchAll(string searchText)
        {
            Mapper.Initialize(x => x.CreateMap<Client, ClientViewModel>());
            IEnumerable<ClientViewModel> clientvm =
                Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(clientService.SearchClients(searchText));
            Mapper.Initialize(x => x.CreateMap<Vehicle, VehicleViewModel>());
            IEnumerable<VehicleViewModel> vehicleViewModel =
                Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleViewModel>>(vehicleService.SearchVehicles(searchText));
            SearchViewModel searchViewModel = new SearchViewModel()
            {
                Clients = clientvm
               ,
                Vehicles = vehicleViewModel
               ,
                SearchText = searchText

            };
            return View("SearchResult", searchViewModel);
        }
    }
}