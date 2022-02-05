using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Commands.DeleteFuel
{
    public class DeleteFuelCommand:IRequest<Fuel>
    {
        public int Id { get; set; }

        public class DeleteFuelCommmandHandler : IRequestHandler<DeleteFuelCommand, Fuel>
        {
            IFuelRepository _fuelRepository;
            IMapper _mapper;

            public DeleteFuelCommmandHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<Fuel> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                var mappedFuel = _mapper.Map<Fuel>(request);
                var deletedFuel = await _fuelRepository.DeleteAsync(mappedFuel);
                return deletedFuel;
            }
        }
    }
}
