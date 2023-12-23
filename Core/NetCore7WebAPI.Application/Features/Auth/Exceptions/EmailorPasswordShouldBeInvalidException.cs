using NetCore7WebAPI.Application.Bases;

namespace NetCore7WebAPI.Application.Features.Auth.Exceptions
{
    public class EmailorPasswordShouldBeInvalidException : BaseExceptions
    {
        
        public EmailorPasswordShouldBeInvalidException() : base("Email adresiniz veya şifreniz hatalıdır !!") { }

    }
}
