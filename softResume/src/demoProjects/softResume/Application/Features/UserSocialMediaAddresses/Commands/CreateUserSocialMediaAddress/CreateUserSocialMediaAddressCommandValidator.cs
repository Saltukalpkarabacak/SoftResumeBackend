using Application.Features.UserSocialMediaAddresses.Constants;
using Application.Features;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress
{
    /// <summary>
    /// Oluşturulacak kullanıcı sosyal medya adresi için gerekli validasyon kuralları
    /// </summary>
    public class CreateUserSocialMediaAddressCommandValidator : AbstractValidator<CreateUserSocialMediaAddressCommand>
    {
        public CreateUserSocialMediaAddressCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaAddressMessages.UserIdIsRequired);

            RuleFor(x => x.GithubUrl)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaAddressMessages.GithubUrlIsRequired);
        }
    }
}
