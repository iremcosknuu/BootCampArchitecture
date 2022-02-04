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

namespace Application.Features.Maintenances.Commands.CreateMaintenance
{
    public class CreateMaintenanceCommand:IRequest<Maintenance>
    {
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CarId { get; set; }

        public class CreateMaintenanceCommandHandler : IRequestHandler<CreateMaintenanceCommand, Maintenance>
        {
            IMaintenanceRepository _maintenanceRepository;
            IMapper _mapper;
            MaintenanceBusienessRules _maintenanceBusienessRules;

            public CreateMaintenanceCommandHandler(IMaintenanceRepository maintenanceRepository, IMapper mapper, MaintenanceBusienessRules maintenanceBusienessRules)
            {
                _maintenanceRepository = maintenanceRepository;
                _mapper = mapper;
                _maintenanceBusienessRules = maintenanceBusienessRules;
            }

            public async Task<Maintenance> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
            {
                var mappedMaintenance = _mapper.Map<Maintenance>(request);
                var createdMaintenance =  await _maintenanceRepository.AddAsync(mappedMaintenance);
                return createdMaintenance;
            }
        }

    }
}
