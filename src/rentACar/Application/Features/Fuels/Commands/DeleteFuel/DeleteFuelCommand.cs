using Application.Features.Fuels.Dtos;
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
    public class DeleteFuelCommand:IRequest<DeleteFuelListDto>
    {
        public int Id { get; set; }

        public class DeleteFuelCommmandHandler : IRequestHandler<DeleteFuelCommand, DeleteFuelListDto>
        {
            IFuelRepository _fuelRepository;
            IMapper _mapper;

            public DeleteFuelCommmandHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<DeleteFuelListDto> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                var mappedFuel = _mapper.Map<Fuel>(request);
                var deletedFuel = await _fuelRepository.DeleteAsync(mappedFuel);
                DeleteFuelListDto deleteFuelListDto = _mapper.Map<DeleteFuelListDto>(deletedFuel);

                return deleteFuelListDto;
            }
        }
    }
}
