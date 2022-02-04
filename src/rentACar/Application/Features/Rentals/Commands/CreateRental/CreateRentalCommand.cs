using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Commands.CreateRental
{
    public class CreateRentalCommand:IRequest<Rental>
    {
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double RentKilometer { get; set; }
        public double ReturnKilometer { get; set; }
        public int CarId { get; set; }

        public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, Rental>
        {
            IRentalRepository _rentalRepository;
            IMapper _mapper;
            RentalBusienessRules _rentalBusienessRules;

            public CreateRentalCommandHandler(IRentalRepository rentalRepository, IMapper mapper, RentalBusienessRules rentalBusienessRules)
            {
                _rentalRepository = rentalRepository;
                _mapper = mapper;
                _rentalBusienessRules = rentalBusienessRules;
            }

            public async Task<Rental> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
            {
                _rentalBusienessRules.CheckIfCarIsRented(request.CarId);
                var  mappedRental = _mapper.Map<Rental>(request);

                var createdRental = await _rentalRepository.AddAsync(mappedRental);
                return createdRental;

            }
        }
    }
}
