using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand:IRequest<UpdateBrandListDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandListDto>
        {
            IBrandRepository _brandRepository;
            IMapper _mapper;

            public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<UpdateBrandListDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var mappedBrand = _mapper.Map<Brand>(request);

                var updatedBrand = await _brandRepository.UpdateAsync(mappedBrand);

                UpdateBrandListDto updateBrandListDto = _mapper.Map<UpdateBrandListDto>(updatedBrand);
                return updateBrandListDto;
            }
        }
    }
}
