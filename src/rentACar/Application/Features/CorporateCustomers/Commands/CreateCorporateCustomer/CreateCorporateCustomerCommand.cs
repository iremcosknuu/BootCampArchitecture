using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer
{
    public class CreateCorporateCustomerCommand:IRequest<CorporateCustomer>
    {
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxId { get; set; }

        public class CorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CorporateCustomer>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;
            IMapper _mapper;
            CorporateCustomerBusienessRules _corporateCustomerBusienessRules;

            public CorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper, CorporateCustomerBusienessRules corporateCustomerBusienessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _corporateCustomerBusienessRules = corporateCustomerBusienessRules;
            }

            public async Task<CorporateCustomer> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _corporateCustomerBusienessRules.TaxNumberCanBotBeDublicated(request.TaxId);

                var mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
                var createCorporateCustomer = await _corporateCustomerRepository.AddAsync(mappedCorporateCustomer);
                return createCorporateCustomer;
            }
        }
    }
}
