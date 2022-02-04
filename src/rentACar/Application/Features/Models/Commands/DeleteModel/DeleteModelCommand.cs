using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.DeleteModel
{
    public class DeleteModelCommand:IRequest<Model>
    {
        public int Id { get; set; }

        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand,Model>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;

            public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<Model> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Model>(request);

                var deletedModel =  await _modelRepository.DeleteAsync(mappedModel);
                return deletedModel;
            }
        }
    }
}
