using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Rules
{
    public class ColorBusienessRules
    {
        IColorRepository _colorRespository;

        public ColorBusienessRules(IColorRepository colorRespository)
        {
            _colorRespository = colorRespository;
        }

        public async Task ColorNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _colorRespository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Color name exists");
            }
        }
    }
}
