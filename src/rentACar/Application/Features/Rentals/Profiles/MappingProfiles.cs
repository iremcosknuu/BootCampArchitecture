using Application.Features.Rentals.Commands.CreateRental;
using Application.Features.Rentals.Commands.DeleteRental;
using Application.Features.Rentals.Commands.UpdateRental;
using Application.Features.Rentals.Dtos;
using Application.Features.Rentals.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Rental, CreateRentalCommand>().ReverseMap();
            CreateMap<Rental, UpdateRentalCommand>().ReverseMap();
            CreateMap<Rental, DeleteRentalCommand>().ReverseMap();
            CreateMap<Rental, RentalListDto>()
                .ForMember(m => m.CarId, opt => opt.MapFrom(m => m.Car));
            CreateMap<Rental, RentalListModel>().ReverseMap();
        }
    }
}
