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
    public class ColorRespository:EfRepositoryBase<Color, BaseDbContext>, IColorRepository
    {
        public ColorRespository(BaseDbContext baseDbContext):base(baseDbContext)
        {

        }
    }
}
