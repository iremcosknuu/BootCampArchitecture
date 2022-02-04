﻿using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarList
{
    public class GetCarListQuery: IRequest<CarListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetCarListQueryHandler : IRequestHandler<GetCarListQuery, CarListModel>
        {
            ICarRepository _carRepository;
            IMapper _mapper;

            public GetCarListQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<CarListModel> Handle(GetCarListQuery request, CancellationToken cancellationToken)
            {
                var cars = await _carRepository.GetListAsync(
                    include: c => c
                        .Include(c => c.Color)
                        .Include(c => c.Model),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );

                var mappedCars = _mapper.Map<CarListModel>(cars);
                return mappedCars;
            }
        }
    }
}
