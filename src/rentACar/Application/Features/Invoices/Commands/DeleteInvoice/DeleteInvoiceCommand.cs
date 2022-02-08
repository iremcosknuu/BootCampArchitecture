using Application.Features.Invoices.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceCommand:IRequest<DeleteInvoiceListDto>
    {
        public int Id { get; set; }

        public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, DeleteInvoiceListDto>
        {
            IInvoiceRepository _invoiceRepository;
            IMapper _mapper;

            public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<DeleteInvoiceListDto> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
            {
                var mapperIndividualCustomer = _mapper.Map<Invoice>(request);
                var deleteInvoice = await _invoiceRepository.DeleteAsync(mapperIndividualCustomer);
                DeleteInvoiceListDto deleteInvoiceListDto = _mapper.Map<DeleteInvoiceListDto>(deleteInvoice);

                return deleteInvoiceListDto;
            }
        }
    }
}
