using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MaintenanceRepository : EfRepositoryBase<Maintenance, BaseDbContext>, IMaintenanceRepository
    {
        public MaintenanceRepository(BaseDbContext baseDbContext):base(baseDbContext)
        {

        }
    }
}
