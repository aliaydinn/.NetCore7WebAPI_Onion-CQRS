using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(15)
            .MinimumLength(2)
            .WithName("İsim Soyisim ");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(60)
                .MinimumLength(8)
                .WithName("Email");

            RuleFor(x=>x.Password)
                .NotEmpty()
                .MaximumLength (20)
                .MinimumLength(6)
                .WithName("Şifre");


            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MaximumLength(20)
                .MinimumLength(6)
                .Equal(x=>x.Password)
                .WithName("Şifre Tekrar");
        }
    }
}
