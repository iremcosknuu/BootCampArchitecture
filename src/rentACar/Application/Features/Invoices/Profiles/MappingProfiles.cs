using Application.Features.Invoices.Commands.CreateInvoice;
using Application.Features.Invoices.Commands.DeleteInvoice;
using Application.Features.Invoices.Commands.UpdateInvoice;
using Application.Features.Invoices.Dtos;
using Application.Features.Invoices.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Invoice, CreateInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, CreateInvoiceListDto>().ReverseMap();

            CreateMap<Invoice, UpdateInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceListDto>().ReverseMap();

            CreateMap<Invoice, DeleteInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, DeleteInvoiceListDto>().ReverseMap();

            CreateMap<Invoice, InvoiceListDto>()
                .ForMember(m => m.Email, opt => opt.MapFrom(m => m.Customer.Email))
                .ForMember(m => m.CustomerName, opt => opt.MapFrom(m => m.Customer.IndividualCustomer != null
                            ? m.Customer.IndividualCustomer.FirstName + " " + m.Customer.IndividualCustomer.LastName
                            : m.Customer.CorporateCustomer.CompanyName))
                .ForMember(m => m.RentDate, opt => opt.MapFrom(m => m.Rental.RentDate))
                .ForMember(m => m.ReturnDate, opt => opt.MapFrom(m => m.Rental.ReturnDate))
                .ReverseMap();
            CreateMap<IPaginate<Invoice>, InvoiceListModel>().ReverseMap();
        }
    }
}
