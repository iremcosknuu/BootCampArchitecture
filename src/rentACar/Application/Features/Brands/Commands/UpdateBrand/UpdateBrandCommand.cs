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
    public class UpdateBrandCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandResponseHandler : IRequestHandler<UpdateBrandCommand>
        {
            IBrandRepository _brandRepository;
            IMapper _mapper;

            public UpdateBrandResponseHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var mappedBrand = _mapper.Map<Brand>(request);

                await _brandRepository.UpdateAsync(mappedBrand);
                return Unit.Value;
            }
        }
    }
}
