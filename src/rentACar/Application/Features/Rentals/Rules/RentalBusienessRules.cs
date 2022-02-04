using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Rules
{
    public class RentalBusienessRules
    {
        IRentalRepository _rentalRepository;

        public RentalBusienessRules(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public bool CheckIfCarIsRented(int carId)
        {
            var result = _rentalRepository.CheckIfCarIsRented(carId);
            if (result)
            {
                throw new BusinessException("Car is rented");
            }
            return result;
        }

    }
}
