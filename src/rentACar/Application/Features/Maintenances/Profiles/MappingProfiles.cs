using Application.Features.Maintenances.Commands.CreateMaintenance;
using Application.Features.Maintenances.Commands.DeleteMaintenance;
using Application.Features.Maintenances.Commands.UpdateMaintenance;
using Application.Features.Maintenances.Dtos;
using Application.Features.Maintenances.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Maintenance, CreateMaintenanceCommand>().ReverseMap();
            CreateMap<Maintenance, CreateMaintenanceListDto>().ReverseMap();

            CreateMap<Maintenance, UpdateMaintenanceCommand>().ReverseMap();
            CreateMap<Maintenance, UpdateMaintenanceListDto>()
                    .ForMember(m => m.CarId, opt => opt.MapFrom(m => m.Car.Id));

            CreateMap<Maintenance, DeleteMaintenanceCommand>().ReverseMap();
            CreateMap<Maintenance, DeleteMaintenanceListDto>()
                    .ForMember(m => m.CarId, opt => opt.MapFrom(m => m.Car.Id));

            CreateMap<Maintenance, MaintenanceListDto>()
                    .ForMember(m => m.CarId, opt => opt.MapFrom(m => m.Car.Id));
            CreateMap<IPaginate<Maintenance>, MaintenanceListModel>().ReverseMap();

        }
    }
}
