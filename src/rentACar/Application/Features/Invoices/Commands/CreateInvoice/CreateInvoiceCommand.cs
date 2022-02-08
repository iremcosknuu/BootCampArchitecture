using Application.Features.Invoices.Dtos;
using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommand:IRequest<CreateInvoiceListDto>
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoicedDate { get; set; }
        public int TotalRentalDate { get; set; }
        public double TotalPrice { get; set; }


        public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand,CreateInvoiceListDto>
        {
            IMapper _mapper;
            IInvoiceRepository _invoiceRepository;
            InvoiceBusienessRules _invoiceBusienessRules;

            public CreateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository, InvoiceBusienessRules invoiceBusienessRules)
            {
                _mapper = mapper;
                _invoiceRepository = invoiceRepository;
                _invoiceBusienessRules = invoiceBusienessRules;
            }

            public async Task<CreateInvoiceListDto> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
            {
                await _invoiceBusienessRules.InvoiceCanNotBeDuplicatedWhenInserted(request.InvoiceNumber);

                var mappedIndividualCustomer = _mapper.Map<Invoice>(request);
                var createdIndividualCustomer = await _invoiceRepository.AddAsync(mappedIndividualCustomer);
                CreateInvoiceListDto createInvoiceListDto = _mapper.Map<CreateInvoiceListDto>(createdIndividualCustomer);

                return createInvoiceListDto;
            }
        }
    }
}
