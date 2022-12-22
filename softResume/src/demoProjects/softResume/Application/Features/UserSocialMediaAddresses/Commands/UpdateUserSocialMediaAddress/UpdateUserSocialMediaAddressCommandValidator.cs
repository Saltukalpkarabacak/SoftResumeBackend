using Application.Features.UserSocialMediaAddresses.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress
{
    /// <summary>
    /// Güncellenecek kullanıcı sosyal medya adresi için gerekli validasyon kuralları
    /// </summary>
    public class UpdateUserSocialMediaAddressCommandValidator : AbstractValidator<UpdateUserSocialMediaAddressCommand>
    {
        public UpdateUserSocialMediaAddressCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaAddressMessages.IdIsRequired);

            RuleFor(p => p.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaAddressMessages.UserIdIsRequired);

            RuleFor(p => p.GithubUrl)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaAddressMessages.GithubUrlIsRequired);
        }
    }
}
