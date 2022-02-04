using Application.Features.Brands.Rules;
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
    public class UpdateModelCommand:IRequest<Model>
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }

        public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand,Model>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;
            ModelBusienesRules _modelBusienesRules;

            public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusienesRules modelBusienesRules)
            {
                this._modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusienesRules = modelBusienesRules;
            }

            public async Task<Model> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBusienesRules.ModelNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedModel = _mapper.Map<Model>(request);

                var createdModel = await _modelRepository.UpdateAsync(mappedModel);
                return createdModel;
            }
        }
    }
}
