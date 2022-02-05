using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Rules
{
    public class FuelBusienessRules
    {
        IFuelRepository _fuelRepository;

        public FuelBusienessRules(IFuelRepository fuelRepository)
        {
            _fuelRepository = fuelRepository;
        }

        public async Task FuelNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _fuelRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Color name exists");
            }
        }
    }
}
