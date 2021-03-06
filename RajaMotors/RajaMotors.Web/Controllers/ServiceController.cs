﻿using AutoMapper;
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
    public class ServiceController : Controller
    {
        // GET: Service

        private IClientService clientService;
        private IVehicleService vehicleService;
        private IServiceService serviceService;
        private UserManager<ApplicationUser> UserManager;

        public ServiceController(IClientService clientService, IVehicleService vehicleService,
            IServiceService serviceService, UserManager<ApplicationUser> userManager)
        {
            this.clientService = clientService;
            this.vehicleService = vehicleService;
            this.serviceService = serviceService;
            UserManager = userManager;
        }

        public ActionResult Index()
        {
            IEnumerable<RajaMotors.Model.Models.Service> services = serviceService.GetServices();
            Mapper.Initialize(x => x.CreateMap<RajaMotors.Model.Models.Service, ServiceViewModel>());

            IEnumerable<ServiceViewModel> servicesvm =
                Mapper.Map<IEnumerable<RajaMotors.Model.Models.Service>, IEnumerable<ServiceViewModel>>(services);
            return View(servicesvm);

        }

        public ActionResult ServiceList(int clientId, int vehicleId, string filterBy, int page = 0,
            string sortBy = "Name")
        {
            filterBy = filterBy.Trim(new Char[] {'\'', '*', '.'});
            IEnumerable<RajaMotors.Model.Models.Service> services = serviceService.GetServiceByPage(clientId, vehicleId,
                page, 5, sortBy, filterBy);
            Mapper.Initialize(x => x.CreateMap<RajaMotors.Model.Models.Service, ServiceViewModel>());

            IEnumerable<ServiceViewModel> servicesvm =
                Mapper.Map<IEnumerable<RajaMotors.Model.Models.Service>, IEnumerable<ServiceViewModel>>(services);

            ServicePageViewModel vmServicePageViewModel = new ServicePageViewModel(filterBy, sortBy);
            vmServicePageViewModel.serviceList = servicesvm;
            vmServicePageViewModel.ClientId = Convert.ToInt16(clientId);
            vmServicePageViewModel.VehicleId = Convert.ToInt16(vehicleId);
            if (Request.IsAjaxRequest())
            {
                return Json(vmServicePageViewModel, JsonRequestBehavior.AllowGet);
            }
            return View(vmServicePageViewModel);
        }

        [HttpGet]
        public ActionResult Create(int vehicleId)
        {
            ServiceViewModel vm = new ServiceViewModel
            {
                VehicleId = vehicleId
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(ServiceViewModel servicemodel)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle = vehicleService.GetVehicleById(servicemodel.VehicleId);
                if (vehicle != null)
                {
                    Mapper.Initialize(x => x.CreateMap<ServiceViewModel, RajaMotors.Model.Models.Service>());
                    RajaMotors.Model.Models.Service service =
                        Mapper.Map<ServiceViewModel, RajaMotors.Model.Models.Service>(servicemodel);
                    service.Vehicle = vehicle;
                    serviceService.Add(service);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int serviceId)
        {
            RajaMotors.Model.Models.Service service = serviceService.GetServiceById(serviceId);
            Mapper.Initialize(x => x.CreateMap<RajaMotors.Model.Models.Service, ServiceViewModel>());
            ServiceViewModel servicevm = Mapper.Map<RajaMotors.Model.Models.Service, ServiceViewModel>(service); 
            return View(servicevm);
        }  

        [HttpPost]
        public ActionResult Edit(ServiceViewModel servicevm)
        {     
            Mapper.Initialize(x => x.CreateMap<ServiceViewModel, RajaMotors.Model.Models.Service>());
            RajaMotors.Model.Models.Service service = Mapper.Map<ServiceViewModel, RajaMotors.Model.Models.Service>(servicevm); 
            serviceService.Update(service);
            return RedirectToAction("ServiceList", new { vehicleId = servicevm.Vehicle.VehicleId, filterBy = "''" });
        }
    }
}