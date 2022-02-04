using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand:IRequest
    {
        public int Id { get; set; }

        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand> 
        {
            ICarRepository _carRepository;
            IMapper _mapper;

            public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
            {
                this._carRepository = carRepository;
                this._mapper = mapper;
            }


            public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var mappedCar = _mapper.Map<Car>(request);
                await _carRepository.DeleteAsync(mappedCar);
                return Unit.Value;
            }
        }
    }
}
