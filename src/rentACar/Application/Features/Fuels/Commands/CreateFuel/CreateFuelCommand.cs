using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Commands.CreateFuel
{
    public class CreateFuelCommand : IRequest<CreateFuelListDto>
    {
        public string Name { get; set; }

        public class CreateFuelCommmandHandler : IRequestHandler<CreateFuelCommand, CreateFuelListDto>
        {
            IFuelRepository _fuelRepository;
            IMapper _mapper;
            FuelBusienessRules _fuelBusienessRules;

            public CreateFuelCommmandHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusienessRules fuelBusienessRules)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
                _fuelBusienessRules = fuelBusienessRules;
            }

            public async Task<CreateFuelListDto> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {
                await _fuelBusienessRules.FuelNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedFuel = _mapper.Map<Fuel>(request);
                var createdFuel = await _fuelRepository.AddAsync(mappedFuel);
                CreateFuelListDto createFuelListDto = _mapper.Map<CreateFuelListDto>(createdFuel);

                return createFuelListDto;
            }
        }
    }
}
