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
    public class DeleteCarCommand:IRequest<Car>
    {
        public int Id { get; set; }

        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand,Car> 
        {
            ICarRepository _carRepository;
            IMapper _mapper;

            public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
            {
                this._carRepository = carRepository;
                this._mapper = mapper;
            }


            public async Task<Car> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var mappedCar = _mapper.Map<Car>(request);
                var deletedCar = await _carRepository.DeleteAsync(mappedCar);
                return deletedCar;
            }
        }
    }
}
