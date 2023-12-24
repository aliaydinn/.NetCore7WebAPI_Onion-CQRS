using NetCore7WebAPI.Application.Bases;

namespace NetCore7WebAPI.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseExceptions
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum zamanınız dolmuştur.Lütfen tekrardan giriş yapınız !") { }


    }
}
