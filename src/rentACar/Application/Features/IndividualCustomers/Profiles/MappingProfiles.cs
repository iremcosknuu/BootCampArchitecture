using Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;
using Application.Features.IndividualCustomers.Commands.DeleteIndividualCustomer;
using Application.Features.IndividualCustomers.Commands.UpdateIndividualCustomer;
using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<IndividualCustomer, CreateIndividualCustomerCommand>()
                .ForMember(x => x.CustomerId,opt => opt.MapFrom(m => m.Customer.Id))
                .ReverseMap();
            CreateMap<IndividualCustomer, CreateIndividualCustomerListDto>()
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(m => m.Customer.Id))
                .ReverseMap();

            CreateMap<IndividualCustomer, UpdateIndividualCustomerCommand>().ReverseMap();
            CreateMap<IndividualCustomer, UpdateIndividualCustomerListDto>().ReverseMap();

            CreateMap<IndividualCustomer, DeleteIndividualCustomerCommand>().ReverseMap();
            CreateMap<IndividualCustomer, DeleteIndividualCustomerListDto>().ReverseMap();

            CreateMap<IndividualCustomer, IndividualCustomerListDto>().ReverseMap();
            CreateMap<IPaginate<IndividualCustomer>, IndividualCustomerListModel>().ReverseMap();
        }
    }
}
