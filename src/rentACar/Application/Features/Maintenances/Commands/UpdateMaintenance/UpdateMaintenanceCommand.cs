using Application.Features.Maintenances.Dtos;
using Application.Features.Maintenances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Commands.UpdateMaintenance
{
    public class UpdateMaintenanceCommand:IRequest<UpdateMaintenanceListDto>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CarId { get; set; }

        public class UpdateMaintenanceCommandHandler : IRequestHandler<UpdateMaintenanceCommand, UpdateMaintenanceListDto>
        {
            IMaintenanceRepository _maintenanceRepository;
            IMapper _mapper;
            MaintenanceBusienessRules _maintenanceBusienessRules;

            public UpdateMaintenanceCommandHandler(IMaintenanceRepository maintenanceRepository, IMapper mapper, MaintenanceBusienessRules maintenanceBusienessRules)
            {
                _maintenanceRepository = maintenanceRepository;
                _mapper = mapper;
                _maintenanceBusienessRules = maintenanceBusienessRules;
            }

            public async Task<UpdateMaintenanceListDto> Handle(UpdateMaintenanceCommand request, CancellationToken cancellationToken)
            {
                var mappedMaintenance = _mapper.Map<Maintenance>(request);
                var updatedMaintenance = await _maintenanceRepository.UpdateAsync(mappedMaintenance);

                UpdateMaintenanceListDto updateMaintenanceListDto = _mapper.Map<UpdateMaintenanceListDto>(updatedMaintenance);
                return updateMaintenanceListDto;
            }
        }
    }
}
