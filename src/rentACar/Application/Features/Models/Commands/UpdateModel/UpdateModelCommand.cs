using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.UpdateModel
{
    public class UpdateModelCommand:IRequest
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }

        public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;

            public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                this._modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Model>(request);

                await _modelRepository.UpdateAsync(mappedModel);
                return Unit.Value;
            }
        }
    }
}
