using Application.Features.CorporateCustomers.Rules;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using Core.Application.Adapters;
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
        IndividualCustomerBusienessRules _individualCustomerBusienessRules;
        CorporateCustomerBusienessRules _corporateCustomerBusienessRules;
        IFindexScoreAdapterService _findexScoreAdapterService;

        public RentalBusienessRules(IRentalRepository rentalRepository, IFindexScoreAdapterService findexScoreAdapterService, CorporateCustomerBusienessRules corporateCustomerBusienessRules, IndividualCustomerBusienessRules individualCustomerBusienessRules)
        {
            _rentalRepository = rentalRepository;
            _findexScoreAdapterService = findexScoreAdapterService;
            _corporateCustomerBusienessRules = corporateCustomerBusienessRules;
            _individualCustomerBusienessRules = individualCustomerBusienessRules;
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
