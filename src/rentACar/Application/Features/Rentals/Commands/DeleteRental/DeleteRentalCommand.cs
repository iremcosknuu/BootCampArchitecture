using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Commands.DeleteRental
{
    public class DeleteRentalCommand : IRequest<Rental>
    {
        public int Id { get; set; }

        public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, Rental>
        {
            IRentalRepository _rentalRepository;
            IMapper _mapper;

            public DeleteRentalCommandHandler(IRentalRepository rentalRepository, IMapper mapper)
            {
                _rentalRepository = rentalRepository;
                _mapper = mapper;
            }

            public async Task<Rental> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
            {
                var mappedRental = _mapper.Map<Rental>(request);
                var deletedRental = await _rentalRepository.DeleteAsync(mappedRental);
                return deletedRental;
            }
        }

    }
}
