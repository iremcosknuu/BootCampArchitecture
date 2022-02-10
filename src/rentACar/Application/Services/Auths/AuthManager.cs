using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Jwt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Auths
{
    public class AuthManager : IAuthService
    {
        IUserOperationClaimRepository _userOperationClaimRepository;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            var userOperationClaims = await _userOperationClaimRepository.GetListAsync(c => c.UserId == user.Id, include: c => c.Include(c => c.OperationClaim));
            List<OperationClaim> operationClaims = userOperationClaims.Items.Select(c => new OperationClaim
            {
                Id = c.OperationClaim.Id,
                Name = c.OperationClaim.Name
            }).ToList();

            var accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task UserPasswordShouldBeMatch(User user, string password)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new BusinessException("Password dont match");

            }
        }
    }
}
