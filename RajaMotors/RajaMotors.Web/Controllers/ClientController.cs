using Microsoft.AspNet.Identity;
using RajaMotors.Model.Models;
using RajaMotors.Service;
using RajaMotors.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RajaMotors.Mappings;

namespace RajaMotors.Web.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Client
        private IClientService clientService;
        private IVehicleService vehicleService;
        private IServiceService serviceService;
        private UserManager<ApplicationUser> UserManager;

        public ClientController(IClientService clientService, IVehicleService vehicleService, IServiceService serviceService, UserManager<ApplicationUser> userManager)
        {
            this.clientService = clientService;
            this.vehicleService = vehicleService;
            this.serviceService = serviceService;
            UserManager = userManager; 
        }

        public ActionResult Index(string SortBy, string FilterBy)
        {
          return  RedirectToActionPermanent("ClientList", new { SortBy = "Name", filterby = "", page = 0 });
            //IEnumerable<Client> clients = clientService.SortAndSearchClients(SortBy,FilterBy);
            //Mapper.Initialize(x => x.CreateMap<Client, ClientViewModel>()); 
            //IEnumerable<ClientViewModel> clientsvm = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(clients);

            //ClientPageViewModel clientPageViewModel = new ClientPageViewModel(FilterBy, SortBy);
            //clientPageViewModel.clientList = clientsvm;
            //return View(); 
        }

        public ActionResult ClientList(string sortBy, string filterBy, int page=0)
        {
            IEnumerable<Client> clients = clientService.GetClientByPage(page, 5, sortBy, filterBy);
            Mapper.Initialize(x => x.CreateMap<Client, ClientViewModel>());
            IEnumerable<ClientViewModel> clientsvm = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(clients);

            ClientPageViewModel clientPageViewModel = new ClientPageViewModel(filterBy, sortBy);
            clientPageViewModel.clientList = clientsvm;

            if (Request.IsAjaxRequest())
            {
                return Json(clientsvm, JsonRequestBehavior.AllowGet);
            }
            return View(clientPageViewModel);
        }


        public ActionResult Detail(int clientId)
        {
            Client client = clientService.GetClientById(clientId);
            Mapper.Initialize(x => x.CreateMap<Client, ClientViewModel>());
            ClientViewModel clientvm = Mapper.Map<Client, ClientViewModel>(client);
            return View(clientvm);
        }

        [HttpGet]
        public ActionResult Create()
        {     
            return View();
        }

        public ActionResult Edit(int clientId)
        {
            Client client = clientService.GetClientById(clientId);
            Mapper.Initialize(x => x.CreateMap<Client, ClientViewModel>());
            ClientViewModel clientvm = Mapper.Map<Client, ClientViewModel>(client);
             
            return View(clientvm);
        }

        [HttpPost]
        public ActionResult Edit(ClientViewModel clientvm)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(x => x.CreateMap<ClientViewModel, Client>());
                Client c = Mapper.Map<ClientViewModel, Client>(clientvm);
                clientService.Update(c);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(ClientViewModel clientmodel)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(x => x.CreateMap<ClientViewModel, Client>());
                Client c = Mapper.Map<ClientViewModel, Client>(clientmodel);
                clientService.Add(c);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(ClientViewModel clientmodel)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(x => x.CreateMap<ClientViewModel, Client>());
                Client c = Mapper.Map<ClientViewModel, Client>(clientmodel);
                clientService.Update(c);
            }
            return View();
        }
        public IEnumerable<Client> SearchClients(string clientName)
        {
            IEnumerable<Client> clients = clientService.SearchClients(clientName);
            Mapper.Initialize(cfg => cfg.CreateMap<IEnumerable<Client>, IEnumerable<ClientViewModel>>());
            IEnumerable<ClientViewModel> listClientViewModel =
                Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(clients);

            return null;
        }
    }
}