using Application.Services.Repositories;
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
    }
}
