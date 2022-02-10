using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusienessRules
    {
        IUserRepository _userRepository;

        public AuthBusienessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = await _userRepository.GetAsync(c => c.Email == email);
            if(result != null)
            {
                throw new BusinessException("User email already exist");
            }

        }

        public async Task UserEmailShouldBeExist(string email)
        {
            var result = await _userRepository.GetAsync(c => c.Email == email);
            if (result == null)
            {
                throw new BusinessException("User email not exist");
            }

        }

        
    }
}
