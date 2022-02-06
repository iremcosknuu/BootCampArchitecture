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

namespace Application.Features.Rentals.Commands.UpdateRental
{
    public class UpdateRentalCommand:IRequest<Rental>
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double RentKilometer { get; set; }
        public double ReturnKilometer { get; set; }
        public int CarId { get; set; }

        public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand,Rental>
        {
            IRentalRepository _rentalRepository;
            IMapper _mapper;
            RentalBusienessRules _rentalBusienessRules;

            public UpdateRentalCommandHandler(IRentalRepository rentalRepository, IMapper mapper, RentalBusienessRules rentalBusienessRules)
            {
                _rentalRepository = rentalRepository;
                _mapper = mapper;
                _rentalBusienessRules = rentalBusienessRules;
            }

            public async Task<Rental> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
            {
                _rentalBusienessRules.CheckIfCarIsRented(request.CarId);
                var mappedRental = _mapper.Map<Rental>(request);

                var updatedRantal = await _rentalRepository.UpdateAsync(mappedRental);
                return updatedRantal; ;
            }
        }
    }
}
