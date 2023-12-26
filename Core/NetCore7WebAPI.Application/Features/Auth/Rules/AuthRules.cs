using NetCore7WebAPI.Application.Bases;
using NetCore7WebAPI.Application.Features.Auth.Exceptions;
using NetCore7WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task TheUserMustNotExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;

        }

        public Task EmailorPasswordShouldBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new EmailorPasswordShouldBeInvalidException();
            return Task.CompletedTask;
        }

        public Task RefreshTokenShouldNotBeExpired(DateTime? expiredTime)
        {
            if (expiredTime <= DateTime.Now) throw new RefreshTokenShouldNotBeExpiredException();
            return Task.CompletedTask;
        }

        public Task EmailShouldBeValid(User? user)
        {
            if (user is null) throw new EmailShouldBeValidException();
            return Task.CompletedTask;
        }
    }
}
