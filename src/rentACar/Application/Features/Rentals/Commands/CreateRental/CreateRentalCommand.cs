using Application.Features.Cars.Rules;
using Application.Features.Maintenances.Rules;
using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
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
        public DateTime? ReturnDate { get; set; }
        public double RentKilometer { get; set; }
        public double ReturnKilometer { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, Rental>
        {
            IRentalRepository _rentalRepository;
            IMapper _mapper;
            RentalBusienessRules _rentalBusienessRules;
            MaintenanceBusienessRules _maintenanceBusienessRules;
            CarBusienessRules _carBusienessRules;

            public CreateRentalCommandHandler(IRentalRepository rentalRepository, IMapper mapper, RentalBusienessRules rentalBusienessRules, MaintenanceBusienessRules maintenanceBusienessRules, CarBusienessRules carBusienessRules)
            {
                _rentalRepository = rentalRepository;
                _mapper = mapper;
                _rentalBusienessRules = rentalBusienessRules;
                _maintenanceBusienessRules = maintenanceBusienessRules;
                _carBusienessRules = carBusienessRules;
            }

            public async Task<Rental> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
            {
                _rentalBusienessRules.CheckIfCarIsRented(request.CarId);
                _maintenanceBusienessRules.CheckIfCarIsMaintenance(request.CarId);

                var  mappedRental = _mapper.Map<Rental>(request);

                var createdRental = await _rentalRepository.AddAsync(mappedRental);
                await _carBusienessRules.ChangeCarState(request.CarId, CarState.Rented);

                return createdRental;

            }
        }
    }
}
