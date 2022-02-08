using Application.Features.Maintenances.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Commands.DeleteMaintenance
{
    public class DeleteMaintenanceCommand:IRequest<DeleteMaintenanceListDto>
    {
        public int Id { get; set; }


        public class DeleteMaintenanceCommandHandler : IRequestHandler<DeleteMaintenanceCommand, DeleteMaintenanceListDto>
        {
            IMaintenanceRepository _maintenanceRepository;
            IMapper _mapper;

            public DeleteMaintenanceCommandHandler(IMaintenanceRepository maintenanceRepository, IMapper mapper)
            {
                _maintenanceRepository = maintenanceRepository;
                _mapper = mapper;
            }

            public async Task<DeleteMaintenanceListDto> Handle(DeleteMaintenanceCommand request, CancellationToken cancellationToken)
            {
                var mappedMaintenance = _mapper.Map<Maintenance>(request);
                var deletedMaintenance = await _maintenanceRepository.DeleteAsync(mappedMaintenance);

                DeleteMaintenanceListDto deleteMaintenanceListDto = _mapper.Map<DeleteMaintenanceListDto>(deletedMaintenance);
                return deleteMaintenanceListDto;
            }
        }
    }
}
