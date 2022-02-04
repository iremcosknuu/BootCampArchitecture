﻿using Application.Features.Brands.Rules;
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
    public class CreateModelCommand : IRequest<Model>
    {
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }

        public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, Model>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;
            ModelBussienesRules _modelBussinessRules;

            public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBussienesRules modelBussinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBussinessRules = modelBussinessRules;
            }

            public async Task<Model> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBussinessRules.ModelNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedModel = _mapper.Map<Model>(request);

                var createModel = await _modelRepository.AddAsync(mappedModel);
                return createModel;
            }
        }
    }
}