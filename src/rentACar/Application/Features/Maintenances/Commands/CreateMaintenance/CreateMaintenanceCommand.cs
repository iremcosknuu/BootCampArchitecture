using Application.Features.Cars.Rules;
using Application.Features.Maintenances.Dtos;
using Application.Features.Maintenances.Rules;
using Application.Features.Rentals.Rules;
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

namespace Application.Features.Maintenances.Commands.CreateMaintenance
{
    public class CreateMaintenanceCommand:IRequest<CreateMaintenanceListDto>
    {
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int CarId { get; set; }


        public class CreateMaintenanceCommandHandler : IRequestHandler<CreateMaintenanceCommand, CreateMaintenanceListDto>
        {
            IMaintenanceRepository _maintenanceRepository;
            IMapper _mapper;
            MaintenanceBusienessRules _maintenanceBusienessRules;
            RentalBusienessRules _rentalBusienessRules;
            CarBusienessRules _carBusienessRules;

            public CreateMaintenanceCommandHandler(IMaintenanceRepository maintenanceRepository, IMapper mapper, MaintenanceBusienessRules maintenanceBusienessRules, RentalBusienessRules rentalBusienessRules, CarBusienessRules carBusienessRules)
            {
                _maintenanceRepository = maintenanceRepository;
                _mapper = mapper;
                _maintenanceBusienessRules = maintenanceBusienessRules;
                _rentalBusienessRules = rentalBusienessRules;
                _carBusienessRules = carBusienessRules;
            }

            public async Task<CreateMaintenanceListDto> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
            {
                _maintenanceBusienessRules.CheckIfCarIsMaintenance(request.CarId);
                _rentalBusienessRules.CheckIfCarIsRented(request.CarId);

                var mappedMaintenance = _mapper.Map<Maintenance>(request);
                var createdMaintenance =  await _maintenanceRepository.AddAsync(mappedMaintenance);
                await _carBusienessRules.ChangeCarState(request.CarId,CarState.Maintenance);

                CreateMaintenanceListDto createMaintenanceListDto = _mapper.Map<CreateMaintenanceListDto>(createdMaintenance);

                return createMaintenanceListDto;
            }
        }

    }
}
