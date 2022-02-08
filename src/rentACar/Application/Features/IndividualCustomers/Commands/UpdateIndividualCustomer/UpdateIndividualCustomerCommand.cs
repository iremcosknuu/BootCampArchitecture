using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands.UpdateIndividualCustomer
{
    public class UpdateIndividualCustomerCommand:IRequest<UpdateIndividualCustomerListDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }

        public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdateIndividualCustomerListDto>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;
            IndividualCustomerBusienessRules _individualCustomerBusienessRules;

            public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusienessRules individualCustomerBusienessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusienessRules = individualCustomerBusienessRules;
            }

            public async Task<UpdateIndividualCustomerListDto> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var individualCustomerToUpdate = await _individualCustomerRepository.GetAsync(c => c.Id == request.Id);

                if (individualCustomerToUpdate == null) throw new BusinessException(" Customer can not be found");
                await _individualCustomerBusienessRules.NationalIdCanBotBeDublicated(request.NationalityId);

                _mapper.Map(request, individualCustomerToUpdate);

                await _individualCustomerRepository.UpdateAsync(individualCustomerToUpdate);

                var mappedIndividualCustomer = _mapper.Map<UpdateIndividualCustomerListDto>(individualCustomerToUpdate);
                return mappedIndividualCustomer;

            }
        }
    }
}
