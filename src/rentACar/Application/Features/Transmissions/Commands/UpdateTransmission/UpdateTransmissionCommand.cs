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

namespace Application.Features.Transmissions.Commands.UpdateTransmission
{
    public class UpdateTransmissionCommand:IRequest<Transmission>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, Transmission>
        {
            ITransmissionRepository _transmissionRepository;
            IMapper _mapper;
            TransmissionBusienessRules _transmissionBusienessRules;

            public UpdateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusienessRules transmissionBusienessRules)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
                _transmissionBusienessRules = transmissionBusienessRules;
            }

            public async Task<Transmission> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
            {
                var mappedTransmission = _mapper.Map<Transmission>(request);

                var updatedTransmission = await _transmissionRepository.UpdateAsync(mappedTransmission);
                return updatedTransmission;
            }
        }
    }
}
