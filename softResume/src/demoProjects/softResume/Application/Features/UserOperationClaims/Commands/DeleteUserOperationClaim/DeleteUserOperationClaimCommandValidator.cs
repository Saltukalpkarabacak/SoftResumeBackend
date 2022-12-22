using Application.Features.UserOperationClaims.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    /// <summary>
    /// Kullanıcı Operasyon claim silmek için validasyon kuralları
    /// </summary>
    public class DeleteUserOperationClaimCommandValidator : AbstractValidator<DeleteUserOperationClaimCommand>
    {
        public DeleteUserOperationClaimCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserOperationClaimMessages.IdIsRequired);

            RuleFor(d => d.Id)
                .GreaterThan(0)
                .WithMessage(UserOperationClaimMessages.IdGreaterThanZero);
        }
    }
}
