using Application.Features.CorporateCustomers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Commands.DeleteCorporateCustomer
{
    public class DeleteCorporateCustomerCommand:IRequest<DeleteCorporateCustomerListDto>
    {
        public int Id { get; set; }

        public class DeleteCorporateCustomerCommandHandler:IRequestHandler<DeleteCorporateCustomerCommand,DeleteCorporateCustomerListDto>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;
            IMapper _mapper;

            public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<DeleteCorporateCustomerListDto> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var mappedColor = _mapper.Map<CorporateCustomer>(request);
                var deletedColor = _corporateCustomerRepository.DeleteAsync(mappedColor);
                DeleteCorporateCustomerListDto deleteCorporateCustomerListDto = _mapper.Map<DeleteCorporateCustomerListDto>(deletedColor);
                return deleteCorporateCustomerListDto;
            }
        }
    }
}
