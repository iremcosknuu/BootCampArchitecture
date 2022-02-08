using Application.Features.Invoices.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Queries.GetInvoiceList
{
    public class GetInvoiceListQuery:IRequest<InvoiceListDto>
    {
        public PageRequest PageRequest { get; set; }

        public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery,InvoiceListDto>
        {
            IMapper _mapper;
            IInvoiceRepository _invoiceRepository;

            public GetInvoiceListQueryHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
            {
                _mapper = mapper;
                _invoiceRepository = invoiceRepository;
            }

            public async Task<InvoiceListDto> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
            {
                var brands = await _invoiceRepository.GetListAsync(
                                        index: request.PageRequest.Page,
                                        size: request.PageRequest.PageSize);

                var mappedInvoices = _mapper.Map<InvoiceListDto>(brands);
                return mappedInvoices;
            }
        }
    }
}
