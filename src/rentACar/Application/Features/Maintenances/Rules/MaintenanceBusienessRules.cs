using Application.Services.Repositories;
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
    }
}
