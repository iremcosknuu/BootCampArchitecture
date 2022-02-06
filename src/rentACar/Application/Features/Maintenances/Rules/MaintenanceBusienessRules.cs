using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Rules
{
    public class MaintenanceBusienessRules
    {
        IMaintenanceRepository _maintenanceRepository;

        public MaintenanceBusienessRules(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public bool CheckIfCarIsMaintenance(int carId)
        {
            var result = _maintenanceRepository.CheckIfCarIsMaintenance(carId);
            if (result)
            {
                throw new BusinessException("Car is maintenance");
            }
            return result;
        }
    }
}
