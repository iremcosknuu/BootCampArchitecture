using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class ModelBusienesRules
    {
        IModelRepository _modelRepository;

        public ModelBusienesRules(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task ModelNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _modelRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Model name exists");
            }
        }

        public async Task BrandIsExist(int id)
        {
            var result = await _modelRepository.GetAsync(b => b.BrandId == id);
            if(result == null)
            {
                throw new BusinessException("Brand is not exist");
            }
        }

        public async Task FuelIsExist(int id)
        {
            var result = await _modelRepository.GetAsync(b => b.FuelId == id);
            if(result == null)
            {
                throw new BusinessException("Fuel is not exist");
            }

        }

        public async Task TransmittionExist(int id)
        {
            var result= await _modelRepository.GetAsync(b => b.TransmissionId == id);
            if(result == null)
            {
                throw new BusinessException("Transmission is not exist");
            }
        }

        
    }
}
