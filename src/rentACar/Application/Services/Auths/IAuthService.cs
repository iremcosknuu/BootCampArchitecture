using Core.Security.Entities;
using Core.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Auths
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);
        public Task UserPasswordShouldBeMatch(User user, string password);
    }
}
