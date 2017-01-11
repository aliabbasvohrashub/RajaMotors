using AutoMapper;
using RajaMotors.Model.Models;
using RajaMotors.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RajaMotors.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Client, ClientViewModel>();
                cfg.CreateMap<Vehicle, VehicleViewModel>();
                cfg.CreateMap<RajaMotors.Model.Models.Service, ServiceViewModel>();
                cfg.CreateMap<UserProfile, UserProfileFormModel>();
                cfg.AddProfile<DomainToViewModelMappingProfile>();
            });

            Mapper.Initialize(x =>
            {
                x.CreateMap<ClientViewModel, Client>();
                x.CreateMap<VehicleViewModel, Vehicle>();
                x.CreateMap<ServiceViewModel, RajaMotors.Model.Models.Service>();
                x.CreateMap<UserProfileFormModel, UserProfile>();
                x.CreateMap<UserFormModel, ApplicationUser>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            }
            );

            //Mapper.Initialize(x =>
            //{
            //    x.AddProfile<DomainToViewModelMappingProfile>();
            //    x.AddProfile<ViewModelToDomainMappingProfile>();
            //});     
        }
    }
}