using NetCore7WebAPI.Application.Bases;

namespace NetCore7WebAPI.Application.Features.Auth.Exceptions
{
    public class EmailShouldBeValidException : BaseExceptions
    {

        public EmailShouldBeValidException() : base(" Email adresi bulunamadı !!") { }

    }
}
