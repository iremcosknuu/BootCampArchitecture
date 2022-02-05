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
    public class CreateFuelCommand : IRequest<Fuel>
    {
        public string Name { get; set; }

        public class CreateFuelCommmandHandler : IRequestHandler<CreateFuelCommand, Fuel>
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

            public async Task<Fuel> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {
                await _fuelBusienessRules.FuelNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedFuel = _mapper.Map<Fuel>(request);
                var createdFuel = await _fuelRepository.AddAsync(mappedFuel);
                return createdFuel;
            }
        }
    }
}
