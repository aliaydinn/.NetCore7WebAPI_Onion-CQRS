using NetCore7WebAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException :BaseExceptions
    {
        public UserAlreadyExistException():base("Böyle bir kullanıcı zaten var") { }

       
    }
}
