using Application.Features.Models.Commands.CreateModel;
using Application.Features.Models.Commands.DeleteModel;
using Application.Features.Models.Commands.UpdateModel;
using Application.Features.Models.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Models
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, UpdateModelCommand>().ReverseMap();
            CreateMap<Model, DeleteModelCommand>().ReverseMap();
            CreateMap<Model,ModelListDto>()
                .ForMember(m => m.BrandName,opt => opt.MapFrom(m => m.Brand.Name))
                .ForMember(m=> m.FuelName, opt => opt.MapFrom(m => m.Fuel.Name))
                .ForMember(m => m.TransmissionName, opt => opt.MapFrom(m => m.Transmission.Name));
            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();

            
        }
    }
}
