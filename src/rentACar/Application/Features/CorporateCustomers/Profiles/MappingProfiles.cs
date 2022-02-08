using Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;
using Application.Features.CorporateCustomers.Commands.DeleteCorporateCustomer;
using Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer;
using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CorporateCustomer, CreateCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, CreateCorporateCustomerListDto>().ReverseMap();

            CreateMap<CorporateCustomer, UpdateCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, UpdateCorporateCustomerListDto>().ReverseMap();

            CreateMap<CorporateCustomer, DeleteCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, DeleteCorporateCustomerListDto>().ReverseMap();

            CreateMap<CorporateCustomer, CorporateCustomerListDto>().ReverseMap();
            CreateMap<IPaginate<CorporateCustomer>, CorporateCustomerListModel>().ReverseMap();

        }
    }
}
