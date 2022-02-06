using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Enums;
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

        public async Task ColorIsExist(int colorId)
        {
            var result = await _carRespository.GetAsync(c => c.ColorId == colorId);
            if(result == null)
            {
                throw new BusinessException("Color is not exist");
            }
        }

        public async Task ModelId(int modelId)
        {
            var result = await _carRespository.GetAsync(c => c.ModelId == modelId);
            if( result == null)
            {
                throw new BusinessException("Model is not exists");
            }
        }

        public async Task ChangeCarState(int id,CarState carstate)
        {
            var result = _carRespository.ChangeCarState(id, carstate);
            if (result == null)
            {
                throw new BusinessException("Car is not exists");
            }
        }

    }
}
