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

namespace Application.Features.Invoices.Commands.UpdateInvoice
{
    public class UpdateInvoiceCommand:IRequest<UpdateInvoiceListDto>
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoicedDate { get; set; }
        public int TotalRentalDate { get; set; }
        public double TotalPrice { get; set; }

        public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, UpdateInvoiceListDto>
        {
            IMapper _mapper;
            IInvoiceRepository _invoiceRepository;
            InvoiceBusienessRules _invoiceBusienessRules;

            public UpdateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository, InvoiceBusienessRules invoiceBusienessRules)
            {
                _mapper = mapper;
                _invoiceRepository = invoiceRepository;
                _invoiceBusienessRules = invoiceBusienessRules;
            }

            public async Task<UpdateInvoiceListDto> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
            {
                await _invoiceBusienessRules.InvoiceCanNotBeDuplicatedWhenInserted(request.InvoiceNumber);
                var mappedBrand = _mapper.Map<Invoice>(request);

                var updatedBrand = await _invoiceRepository.UpdateAsync(mappedBrand);

                UpdateInvoiceListDto updateInvoiceListDto = _mapper.Map<UpdateInvoiceListDto>(updatedBrand);
                return updateInvoiceListDto;
            }


        }
    }
}
