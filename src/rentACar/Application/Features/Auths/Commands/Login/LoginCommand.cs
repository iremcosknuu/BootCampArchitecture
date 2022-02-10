using Application.Features.Auths.Rules;
using Application.Services.Auths;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Jwt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand:IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            IUserRepository _userRepository;
            IAuthService _authService;
            AuthBusienessRules _authBusienessRules;

            public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusienessRules authBusienessRules)
            {
                _userRepository = userRepository;
                _authService = authService;
                _authBusienessRules = authBusienessRules;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                await _authBusienessRules.UserEmailShouldBeExist(request.UserForLoginDto.Email);

                var user = await _userRepository.GetAsync(c => c.Email == request.UserForLoginDto.Email);

                await _authService.UserPasswordShouldBeMatch(user ,request.UserForLoginDto.Password);

                var accessToken = await _authService.CreateAccessToken(user);
                return accessToken;
            }
        }
    }
}
