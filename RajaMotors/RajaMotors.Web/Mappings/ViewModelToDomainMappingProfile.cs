using AutoMapper;
using RajaMotors.Model.Models;
using RajaMotors.Web.ViewModels;
//using RajaMotors.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RajaMotors.Mappings
{

    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<ClientViewModel, Client>();
            //    cfg.CreateMap<VehicleViewModel, Vehicle>();
            //    cfg.CreateMap<ServiceViewModel, RajaMotors.Model.Models.Service>();
            //    cfg.CreateMap<UserProfileFormModel, UserProfile>();
            //    cfg.CreateMap<UserFormModel, ApplicationUser>();
            //}
            //);
        }
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        } 
    }
}