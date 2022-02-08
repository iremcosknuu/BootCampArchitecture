using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommand:IRequest<CreateCarListDto>
    {
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }

        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarListDto>
        {
            ICarRepository _carRepository;
            IMapper _mapper;
            CarBusienessRules _carBusienessRules;

            public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusienessRules carBusienessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusienessRules = carBusienessRules;
            }


            public async Task<CreateCarListDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusienessRules.ColorIsExist(request.ColorId);
                await _carBusienessRules.ModelId(request.ModelId);

                var mappedCar = _mapper.Map<Car>(request);
                var createdCar = await _carRepository.AddAsync(mappedCar);

                CreateCarListDto createCarListDto = _mapper.Map<CreateCarListDto>(createdCar);

                return createCarListDto;
            }
        }
    }
}
