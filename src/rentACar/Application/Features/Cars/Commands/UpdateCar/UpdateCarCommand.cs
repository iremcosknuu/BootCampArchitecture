using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand:IRequest<UpdateCarListDto>
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public int FindexScore { get; set; }

        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarListDto>
        {
            ICarRepository _carRepository;
            IMapper _mapper;
            CarBusienessRules _carBusienessRules;

            public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusienessRules carBusienessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusienessRules = carBusienessRules;
            }


            public async Task<UpdateCarListDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusienessRules.ColorIsExist(request.ColorId);
                await _carBusienessRules.ModelId(request.ModelId);

                var mappedCar = _mapper.Map<Car>(request);

                var updatedCar = await _carRepository.UpdateAsync(mappedCar);

                UpdateCarListDto updateCarListDto = _mapper.Map<UpdateCarListDto>(updatedCar);
                return updateCarListDto;

            }
        }
    }
}
