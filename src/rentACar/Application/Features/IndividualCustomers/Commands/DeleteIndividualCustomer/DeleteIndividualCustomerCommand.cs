using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands.DeleteIndividualCustomer
{
    public class DeleteIndividualCustomerCommand: IRequest<IndividualCustomer>
    {
        public int Id { get; set; }

        public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, IndividualCustomer>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;

            public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<IndividualCustomer> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var mapperIndividualCustomer = _mapper.Map<IndividualCustomer>(request);
                var deletedIndividualCustomer = await _individualCustomerRepository.DeleteAsync(mapperIndividualCustomer);
                return deletedIndividualCustomer;
            }
        }
    }
}
