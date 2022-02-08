using Application.Features.CorporateCustomers.Dtos;
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

namespace Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer
{
    public class UpdateCorporateCustomerCommand:IRequest<UpdateCorporateCustomerListDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxId { get; set; }

        public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdateCorporateCustomerListDto>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;
            IMapper _mapper;
            CorporateCustomerBusienessRules _corporateCustomerBusienessRules;

            public UpdateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper, CorporateCustomerBusienessRules corporateCustomerBusienessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _corporateCustomerBusienessRules = corporateCustomerBusienessRules;
            }

            public async Task<UpdateCorporateCustomerListDto> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _corporateCustomerBusienessRules.TaxNumberCanBotBeDublicated(request.TaxId);
                var mappedColor = _mapper.Map<CorporateCustomer>(request);
                var updatedColor = await _corporateCustomerRepository.UpdateAsync(mappedColor);

                UpdateCorporateCustomerListDto updateCorporateCustomerListDto = _mapper.Map<UpdateCorporateCustomerListDto>(request);
                return updateCorporateCustomerListDto;
            }
        }
    }
}
