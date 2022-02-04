using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules
{
    public class CarBusienessRules
    {
        ICarRepository _carRespository;

        public CarBusienessRules(ICarRepository carRespository)
        {
            _carRespository = carRespository;
        }

        public async Task ColorIsExist(int id)
        {
            var result = await _carRespository.GetAsync(c => c.ColorId == id);
            if(result == null)
            {
                throw new BusinessException("Color is not exist");
            }
        }

        public async Task ModelId(int id)
        {
            var result = await _carRespository.GetAsync(c => c.ModelId == id);
            if( result == null)
            {
                throw new BusinessException("Model is not exists");
            }
        }

    }
}
