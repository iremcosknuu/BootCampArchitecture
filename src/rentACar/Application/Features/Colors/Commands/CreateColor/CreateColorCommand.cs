using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.CreateColor
{
    public class CreateColorCommand:IRequest<Color>
    {
        public string Name { get; set; }

        public class CreateColorCommmandHandler : IRequestHandler<CreateColorCommand, Color>
        {
            IColorRepository _colorRepository;
            IMapper _mapper;
            ColorBusienessRules _colorBusienessRules;

            public CreateColorCommmandHandler(IColorRepository colorRepository, IMapper mapper, ColorBusienessRules colorBusienessRules)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
                _colorBusienessRules = colorBusienessRules;
            }

            public async Task<Color> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                await _colorBusienessRules.ColorNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedColor = _mapper.Map<Color>(request.Name);
                var createdColor = await _colorRepository.AddAsync(mappedColor);
                return createdColor;
            }
        }
    }
}
