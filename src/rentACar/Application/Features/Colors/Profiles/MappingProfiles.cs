using Application.Features.Colors.Commands.CreateColor;
using Application.Features.Colors.Commands.DeleteColor;
using Application.Features.Colors.Commands.UpdateColor;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Color, CreateColorCommand>().ReverseMap();
            CreateMap<Color, UpdateColorCommand>().ReverseMap();
            CreateMap<Color, DeleteColorCommand>().ReverseMap();

        }
    }
}
