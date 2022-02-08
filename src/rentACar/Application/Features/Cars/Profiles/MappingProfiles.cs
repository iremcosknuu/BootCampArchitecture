using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Commands.DeleteCar;
using Application.Features.Cars.Commands.UpdateCar;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, CreateCarListDto>()
                .ForMember(c => c.ColorId, opt => opt.MapFrom(c => c.Color.Id))
                .ForMember(c => c.ModelId, opt => opt.MapFrom(c => c.Model.Id));

            CreateMap<Car, UpdateCarCommand>().ReverseMap();
            CreateMap<Car, UpdateCarListDto>()
                .ForMember(c => c.ColorId, opt => opt.MapFrom(c => c.Color.Id))
                .ForMember(c => c.ModelId, opt => opt.MapFrom(c => c.Model.Id));

            CreateMap<Car, DeleteCarCommand>().ReverseMap();
            CreateMap<Car, DeleteCarListDto>()
                .ForMember(c => c.ColorId, opt => opt.MapFrom(c => c.Color.Id))
                .ForMember(c => c.ModelId, opt => opt.MapFrom(c => c.Model.Id));

            CreateMap<Car, CarListDto>()
                .ForMember(c => c.ColorName, opt => opt.MapFrom(c => c.Color.Name))
                .ForMember(c => c.ModelName, opt => opt.MapFrom(c => c.Model.Name));
            CreateMap<IPaginate<Car>, CarListModel>().ReverseMap();

        }
    }
}
