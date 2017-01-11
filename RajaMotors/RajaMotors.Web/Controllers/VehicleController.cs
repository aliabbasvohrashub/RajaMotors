using Microsoft.AspNet.Identity;
using RajaMotors.Model.Models;
using RajaMotors.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RajaMotors.Web.ViewModels;

namespace RajaMotors.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        // GET: Vehicle
        private IClientService clientService;
        private IVehicleService vehicleService;
        private IServiceService serviceService;
        private UserManager<ApplicationUser> UserManager;

        public VehicleController(IClientService clientService, IVehicleService vehicleService, IServiceService serviceService, UserManager<ApplicationUser> userManager)
        {
            this.clientService = clientService;
            this.vehicleService = vehicleService;
            this.serviceService = serviceService;
            UserManager = userManager;
        }


        public ActionResult Index()
        {
            IEnumerable<Vehicle> vehicles = vehicleService.GetVehicles();
            Mapper.Initialize(x => x.CreateMap<Vehicle, VehicleViewModel>());

            IEnumerable<VehicleViewModel> vehiclesvm = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleViewModel>>(vehicles);
            return View(vehiclesvm);
        }
    }
}