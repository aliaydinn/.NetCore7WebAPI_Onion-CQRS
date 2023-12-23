using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NetCore7WebAPI.Application.Bases;
using NetCore7WebAPI.Application.Features.Auth.Rules;
using NetCore7WebAPI.Application.Interfaces.AutoMapper;
using NetCore7WebAPI.Application.Interfaces.Tokens;
using NetCore7WebAPI.Application.Interfaces.UnitOfWorks;
using NetCore7WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler ,IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly AuthRules authRules;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;

        public LoginCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor,UserManager<User> userManager,RoleManager<Role> roleManager,AuthRules authRules,ITokenService tokenService,IConfiguration configuration) :base(mapper, unitOfWork,httpContextAccessor)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.authRules = authRules;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword=await userManager.CheckPasswordAsync(user, request.Password);
            await authRules.EmailorPasswordShouldBeInvalid(user, checkPassword);

            IList<string> roles = await userManager.GetRolesAsync(user);

            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            var refreshToken = tokenService.GenerateRefreshToken();
            _ = int.TryParse(configuration["JWT:RefreshTokenValidityDay"], out int refreshTokenValidityDay);

            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpriyTime = DateTime.Now.AddDays(refreshTokenValidityDay);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccesToken", stringToken);
            return new()
            {
                Token = stringToken,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }
    }
}
