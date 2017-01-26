using Microsoft.AspNet.Identity;
using RajaMotors.Model.Models;
using RajaMotors.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RajaMotors.Data.Repository;
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


        public ActionResult Index(int? clientId)
        {
            if (clientId == null)
            {
                IEnumerable<Vehicle> vehicles = vehicleService.GetVehicles();
                Mapper.Initialize(x => x.CreateMap<Vehicle, VehicleViewModel>());

                IEnumerable<VehicleViewModel> vehiclesvm = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleViewModel>>(vehicles);
                return View(vehiclesvm);
            }
            else
            {
                IEnumerable<Vehicle> vehicle = vehicleService.ClientVehicles(Convert.ToInt16(clientId));
                Mapper.Initialize(v => v.CreateMap<Vehicle, VehicleViewModel>());

                IEnumerable<VehicleViewModel> vehiclevm = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleViewModel>>(vehicle);
                return View(vehiclevm);
            }
        }


        public ActionResult VehicleList(int? clientId, string filterBy, int page = 0, string sortBy = "Name")
        { 
            filterBy = filterBy.Trim(new Char[] { '\'', '*', '.' });
            IEnumerable<Vehicle> vehicles = vehicleService.GetVehiclessByPage(page, 5, sortBy, filterBy, clientId);
            Mapper.Initialize(x => x.CreateMap<Vehicle, VehicleViewModel>());

            IEnumerable<VehicleViewModel> vehiclesvm = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleViewModel>>(vehicles);

            foreach (var item in vehiclesvm)
            {
                item.serviceCount = serviceService.serviceCount(item.VehicleId);
            }

            VehiclePageViewModel vmVehiclePageViewModel = new VehiclePageViewModel(filterBy, sortBy);
            vmVehiclePageViewModel.vehicleList = vehiclesvm;
            vmVehiclePageViewModel.ClientId =  Convert.ToInt16(clientId);
            if (Request.IsAjaxRequest())
            {
                return Json(vmVehiclePageViewModel, JsonRequestBehavior.AllowGet);
            }
            return View(vmVehiclePageViewModel);
        }

        public ActionResult Create(int customerId)
        {
            VehicleViewModel vehiclevm = new VehicleViewModel();
            vehiclevm.ClientId = customerId;
            return View(vehiclevm);
        }

        [HttpPost]
        public ActionResult Create(VehicleViewModel vmVehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                Client cl = clientService.GetClientById(vmVehicleViewModel.ClientId);

                Mapper.Initialize(x => x.CreateMap<VehicleViewModel, Vehicle>());
                Vehicle vehicle = Mapper.Map<VehicleViewModel, Vehicle>(vmVehicleViewModel);
                vehicle.Client = cl;
                vehicleService.AddVehicle(vehicle);
            }
            return RedirectToAction("VehicleList", new {clientId = vmVehicleViewModel.ClientId, filterBy = "''"});
        }
        public ActionResult Edit(int vehicleId)
        {
            Vehicle vehicle = vehicleService.GetVehicleById(vehicleId);
            Mapper.Initialize(x => x.CreateMap<Vehicle, VehicleViewModel>());
            VehicleViewModel vehiclevm = Mapper.Map<Vehicle, VehicleViewModel>(vehicle); 
            return View(vehiclevm);
        }

        [HttpPost]
        public ActionResult Edit(VehicleViewModel vehiclevm)
        {
          //  Vehicle vehicle = vehicleService.GetVehicleById(vehiclevm.VehicleId);
            Mapper.Initialize(x => x.CreateMap<VehicleViewModel, Vehicle>());
            Vehicle vehicle1 = Mapper.Map<VehicleViewModel, Vehicle>(vehiclevm);
           // vehicle1.Client = vehicleService.GetVehicleById(vehiclevm.VehicleId).Client;
           // vehicle1.ClientId = vehicleService.GetVehicleById(vehiclevm.VehicleId).Client.ClientId;
            vehicleService.Update(vehicle1); 
            return RedirectToAction("VehicleList", new {clientId = vehiclevm.ClientId, filterBy = "''"});
        }

        public ActionResult Details(int vehicleId)
        {
            Vehicle vehicle = vehicleService.GetVehicleById(vehicleId);
            Mapper.Initialize(v => v.CreateMap<Vehicle, VehicleViewModel>());

            VehicleViewModel vehiclevm = Mapper.Map<Vehicle, VehicleViewModel>(vehicle);
            return View(vehiclevm);
        }
    }
}