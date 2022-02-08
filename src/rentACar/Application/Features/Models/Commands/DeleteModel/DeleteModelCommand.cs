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

namespace Application.Features.Models.Commands.DeleteModel
{
    public class DeleteModelCommand:IRequest<DeleteModelListDto>
    {
        public int Id { get; set; }

        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeleteModelListDto>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;

            public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<DeleteModelListDto> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Model>(request);

                var deletedModel =  await _modelRepository.DeleteAsync(mappedModel);
                DeleteModelListDto deleteModelListDto = _mapper.Map< DeleteModelListDto >(deletedModel);

                return deleteModelListDto;
            }
        }
    }
}
