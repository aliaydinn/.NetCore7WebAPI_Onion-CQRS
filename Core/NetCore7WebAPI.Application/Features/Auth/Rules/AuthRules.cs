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
    public class AuthRules :BaseRules
    {
        public Task TheUserMustNotExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;

        }
    }
}
