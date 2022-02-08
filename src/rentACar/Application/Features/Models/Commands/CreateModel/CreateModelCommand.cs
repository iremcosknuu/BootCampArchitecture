using Application.Features.Brands.Rules;
using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.CreateModel
{
    public class CreateModelCommand : IRequest<CreateModelListDto>
    {
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }

        public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreateModelListDto>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;
            ModelBusienesRules _modelBusinessRules;

            public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusienesRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<CreateModelListDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBusinessRules.ModelNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedModel = _mapper.Map<Model>(request);

                var createModel = await _modelRepository.AddAsync(mappedModel);
                CreateModelListDto createModelListDto = _mapper.Map<CreateModelListDto>(createModel);

                return createModelListDto;
            }
        }
    }
}
