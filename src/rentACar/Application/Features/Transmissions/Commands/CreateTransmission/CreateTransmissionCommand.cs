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

namespace Application.Features.Transmissions.Commands.CreateTransmission
{
    public class CreateTransmissionCommand:IRequest<Transmission>
    {
        public string Name { get; set; }

        public class CreateTransmissionCommandHandler:IRequestHandler<CreateTransmissionCommand,Transmission>
        {
            ITransmissionRepository _transmissionRepository;
            IMapper _mapper;
            TransmissionBusienessRules _transmissionBusienessRules;

            public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusienessRules transmissionBusienessRules)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
                _transmissionBusienessRules = transmissionBusienessRules;
            }

            public async Task<Transmission> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {
                await _transmissionBusienessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedTransmission = _mapper.Map<Transmission>(request);
                
                var createdTransmission =  await _transmissionRepository.AddAsync(mappedTransmission);
                return createdTransmission;
            }
        }
    }
}
