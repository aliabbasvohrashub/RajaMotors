using AutoMapper;
using PagedList;
using RajaMotors.Model.Models;
using RajaMotors.Web.Core;
using RajaMotors.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RajaMotors.Web.ViewModels;

namespace RajaMotors.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        { 
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Client, ClientViewModel>();
            //    cfg.CreateMap<Vehicle, VehicleViewModel>();
            //    cfg.CreateMap<RajaMotors.Model.Models.Service, ServiceViewModel>();
            //    cfg.CreateMap<UserProfile, UserProfileFormModel>();
            //}
            //);
        }
         
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        } 
    }
}