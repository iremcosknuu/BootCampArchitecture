using Application.Features.IndividualCustomers.Dtos;
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
    public class DeleteIndividualCustomerCommand: IRequest<DeleteIndividualCustomerListDto>
    {
        public int Id { get; set; }

        public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeleteIndividualCustomerListDto>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;

            public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<DeleteIndividualCustomerListDto> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var mapperIndividualCustomer = _mapper.Map<IndividualCustomer>(request);
                var deletedIndividualCustomer = await _individualCustomerRepository.DeleteAsync(mapperIndividualCustomer);
                DeleteIndividualCustomerListDto deleteIndividualCustomerListDto = _mapper.Map<DeleteIndividualCustomerListDto>(deletedIndividualCustomer);

                return deleteIndividualCustomerListDto;
            }
        }
    }
}
