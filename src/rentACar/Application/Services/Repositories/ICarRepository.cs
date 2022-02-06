using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface ICarRepository:IAsyncRepository<Car>
    {
        bool ChangeCarState(int carId,CarState carState);
    }
}
