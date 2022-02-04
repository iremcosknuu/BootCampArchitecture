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
    public class DeleteModelCommand:IRequest
    {
        public int Id { get; set; }

        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;

            public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Model>(request);

                await _modelRepository.DeleteAsync(mappedModel);
                return Unit.Value;
            }
        }
    }
}
