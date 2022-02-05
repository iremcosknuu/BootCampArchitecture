using Application.Features.Cars.Models;
using Application.Features.Rentals.Models;
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

namespace Application.Features.Rentals.Queries.GetRentalList
{
    public class GetRentalListQuery : IRequest<RentalListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetRentalListHandler : IRequestHandler<GetRentalListQuery , RentalListModel>
        {
            IRentalRepository _rentalRepository;
            IMapper _mapper;

            public GetRentalListHandler(IRentalRepository rentalRepository, IMapper mapper)
            {
                _rentalRepository = rentalRepository;
                _mapper = mapper;
            }

            public async Task<RentalListModel> Handle(GetRentalListQuery request, CancellationToken cancellationToken)
            {
                var rentals = await _rentalRepository.GetListAsync(
                    include: r => r
                        .Include(r => r.Car),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );

                var mappedRentals = _mapper.Map<RentalListModel>(rentals);
                return mappedRentals;
            }
        }
    }
}
