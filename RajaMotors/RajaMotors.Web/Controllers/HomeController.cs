using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RajaMotors.Model.Models;
using RajaMotors.Service;
using RajaMotors.Web.ViewModels;

namespace RajaMotors.Web.Controllers
{
    public class HomeController : Controller 
    {
        private IClientService clientService;
        private IVehicleService vehicleService;
        private readonly IServiceService serviceService;
        private UserManager<ApplicationUser> UserManager;

        public HomeController(IClientService clientService, IVehicleService vehicleService, IServiceService serviceService, UserManager<ApplicationUser> userManager)
        {
            this.clientService = clientService;
            this.vehicleService = vehicleService;
            this.serviceService = serviceService;
            UserManager = userManager;
        }

        public ActionResult Index()
        {
            IEnumerable<RajaMotors.Model.Models.Service> allDueServices = serviceService.GetAllDueServices();
            Mapper.Initialize(x=>x.CreateMap<RajaMotors.Model.Models.Service,ServiceViewModel>());
             
            IEnumerable<ServiceViewModel> vmallDueServices =
                Mapper.Map<IEnumerable<RajaMotors.Model.Models.Service>, IEnumerable<ServiceViewModel>>(allDueServices);
            return View(vmallDueServices);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}