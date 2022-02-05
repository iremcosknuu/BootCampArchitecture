using Application.Features.Transmissions.Commands.CreateTransmission;
using Application.Features.Transmissions.Commands.DeleteTransmisson;
using Application.Features.Transmissions.Commands.UpdateTransmission;
using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, UpdateTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, DeleteTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, TransmissionListDto>().ReverseMap();
            CreateMap<IPaginate<Transmission>, TransmissionListModel>().ReverseMap();
        }
    }
}
