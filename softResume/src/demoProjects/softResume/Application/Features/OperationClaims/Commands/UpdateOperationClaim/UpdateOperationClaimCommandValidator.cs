using Application.Features.OperationClaims.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    /// <summary>
    /// Operasyon claim güncellemek için validasyon kuralları
    /// </summary>
    public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(OperationClaimMessages.IdIsRequired);

            RuleFor(d => d.Id)
                .GreaterThan(0)
                .WithMessage(OperationClaimMessages.GreaterThanZero);

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage(OperationClaimMessages.NameIsRequired);
        }
    }
}
