using Application.Features.CorporateCustomers.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Queries.GetCorporateCustomerList
{
    public class GetCorporateCustomerListQuery:IRequest<CorporateCustomerListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetCorporateCustomerListQueryHandler : IRequestHandler<GetCorporateCustomerListQuery, CorporateCustomerListModel>
        {
            IMapper _mapper;
            ICorporateCustomerRepository _corporateCustomerRepository;

            public GetCorporateCustomerListQueryHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository)
            {
                _mapper = mapper;
                _corporateCustomerRepository = corporateCustomerRepository;
            }

            public async Task<CorporateCustomerListModel> Handle(GetCorporateCustomerListQuery request, CancellationToken cancellationToken)
            {
                var corporateCustomers = await _corporateCustomerRepository.GetListAsync(
                                            index: request.PageRequest.Page,
                                            size: request.PageRequest.PageSize);

                var mappedCorporateCustomers = _mapper.Map<CorporateCustomerListModel>(corporateCustomers);
                return mappedCorporateCustomers;
            }
        }
    }
}
