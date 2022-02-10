using Application.Features.Auths.Rules;
using Application.Services.Auths;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Jwt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommand:IRequest<AccessToken>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }

        public class RegisterCommandHandler : IRequestHandler< RegisterCommand, AccessToken>
        {
            IUserRepository _userRepository;
            IAuthService _authService;
            AuthBusienessRules _authBusienessRules;

            public RegisterCommandHandler(IUserRepository userRepository, AuthBusienessRules authBusienessRules, IAuthService authService = null)
            {
                _userRepository = userRepository;
                _authBusienessRules = authBusienessRules;
                _authService = authService;
            }

            public async Task<AccessToken> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusienessRules.UserEmailCanNotBeDuplicatedWhenInserted(request.UserForRegisterDto.Email);

                byte[] passworHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passworHash, out passwordSalt);
                User user = new User { 
                    Email= request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passworHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

                 var createdUser =await _userRepository.AddAsync(user);

                var accessToken = await _authService.CreateAccessToken(createdUser);
                return accessToken;

            }
        }
    }
}
