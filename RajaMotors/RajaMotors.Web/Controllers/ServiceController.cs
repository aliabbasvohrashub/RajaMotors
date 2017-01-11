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
    public class ServiceController : Controller
    {
        // GET: Service

        private IClientService clientService;
        private IVehicleService vehicleService;
        private IServiceService serviceService;
        private UserManager<ApplicationUser> UserManager;

        public ServiceController(IClientService clientService, IVehicleService vehicleService, IServiceService serviceService, UserManager<ApplicationUser> userManager)
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

            IEnumerable<ServiceViewModel> servicesvm = Mapper.Map<IEnumerable<RajaMotors.Model.Models.Service>, IEnumerable<ServiceViewModel>>(services);
            return View(servicesvm);
             
        }
    }
}