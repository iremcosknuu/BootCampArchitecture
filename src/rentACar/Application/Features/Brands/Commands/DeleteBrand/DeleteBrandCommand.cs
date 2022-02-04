using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand:IRequest<Brand>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommand,Brand>
        {
            IBrandRepository _brandRespository;
            IMapper _mapper;

            public DeleteBrandCommandHandler(IBrandRepository brandRespository, IMapper mapper)
            {
                _brandRespository = brandRespository;
                _mapper = mapper;
            }

            public async Task<Brand> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                var mapperBrand = _mapper.Map<Brand>(request);
                var deletedBrand = await _brandRespository.DeleteAsync(mapperBrand);
                return deletedBrand;
            }
        }
    }
}
