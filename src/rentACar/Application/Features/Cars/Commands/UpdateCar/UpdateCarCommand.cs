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
    public class UpdateCarCommand:IRequest
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }

        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
        {
            ICarRepository _carRepository;
            IMapper _mapper;

            public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }


            public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                var mappedCar = _mapper.Map<Car>(request);

                await _carRepository.UpdateAsync(mappedCar);
                return Unit.Value;

            }
        }
    }
}
