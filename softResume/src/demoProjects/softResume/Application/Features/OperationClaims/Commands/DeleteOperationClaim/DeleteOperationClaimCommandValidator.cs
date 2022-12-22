using Application.Features.OperationClaims.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    /// <summary>
    /// Operasyon claim silmek için validasyon kuralları
    /// </summary>
    public class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
    {
        public DeleteOperationClaimCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(OperationClaimMessages.IdIsRequired);

            RuleFor(d => d.Id)
                .GreaterThan(0)
                .WithMessage(OperationClaimMessages.GreaterThanZero);
        }
    }
}
