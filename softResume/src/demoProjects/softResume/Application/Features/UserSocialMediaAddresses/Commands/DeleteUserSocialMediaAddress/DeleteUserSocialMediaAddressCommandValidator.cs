using Application.Features.UserSocialMediaAddresses.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress
{
    /// <summary>
    /// Silinecek kullanıcı sosyal medya adresi için gerekli validasyon kuralları
    /// </summary>
    public class DeleteUserSocialMediaAddressCommandValidator : AbstractValidator<DeleteUserSocialMediaAddressCommand>
    {
        public DeleteUserSocialMediaAddressCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaAddressMessages.IdIsRequired);

        }
    }
}
