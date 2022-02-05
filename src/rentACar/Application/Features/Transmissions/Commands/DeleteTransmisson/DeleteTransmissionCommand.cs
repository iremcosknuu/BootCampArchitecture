using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.DeleteTransmisson
{
    public class DeleteTransmissionCommand:IRequest<Transmission>
    {
        public int Id { get; set; }

        public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, Transmission>
        {
            ITransmissionRepository _transmissionRepository;
            IMapper _mapper;
            TransmissionBusienessRules _transmissionBusienessRules;

            public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusienessRules transmissionBusienessRules)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
                _transmissionBusienessRules = transmissionBusienessRules;
            }

            public async Task<Transmission> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
            {
                var mappedTransmission = _mapper.Map<Transmission>(request);

                var deletedTransmission = await _transmissionRepository.DeleteAsync(mappedTransmission);
                return deletedTransmission;
            }
        }
    }
}
