using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand: IRequest<CreateUserDto>
    {
        public int MyProperty { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
        {
            IMapper _mapper;
            IUserRepository _userRepository;

            public Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
