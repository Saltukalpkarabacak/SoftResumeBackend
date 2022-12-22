using Application.Features.Auths.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    /// <summary>
    /// Kullanıcı giriş işlemleri için validasyon sınıfı
    /// </summary>
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.UserForLoginDto.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(AuthMessages.UserEmailIsRequired);

            RuleFor(x => x.UserForLoginDto.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(AuthMessages.UserPasswordIsRequired);

            // RuleFor(x=>x.UserForLoginDto.AuthenticatorCode)
            //     .NotEmpty()
            //     .NotNull()
            //     .WithMessage(AuthMessages.UserAuthenticatorCodeIsRequired);
        }
    }
}
