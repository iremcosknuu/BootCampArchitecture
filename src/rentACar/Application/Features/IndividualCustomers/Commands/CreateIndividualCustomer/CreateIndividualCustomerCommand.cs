using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using AutoMapper;
using Application.Features.IndividualCustomers.Dtos;

namespace Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer
{
    public class CreateIndividualCustomerCommand:IRequest<CreateIndividualCustomerListDto>
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }

        public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerListDto>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;

            public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<CreateIndividualCustomerListDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var mappedIndividualCustomer = _mapper.Map<IndividualCustomer>(request);
                var createdIndividualCustomer = await _individualCustomerRepository.AddAsync(mappedIndividualCustomer);
                CreateIndividualCustomerListDto createIndividualCustomerListDto = _mapper.Map<CreateIndividualCustomerListDto>(createdIndividualCustomer);

                return createIndividualCustomerListDto;
            }
        }
    }
}
