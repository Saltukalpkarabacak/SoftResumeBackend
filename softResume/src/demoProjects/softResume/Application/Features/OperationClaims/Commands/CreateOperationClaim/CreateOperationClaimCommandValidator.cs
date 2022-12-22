using Application.Features.OperationClaims.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    /// <summary>
    /// Operasyon claim oluşturmak için validasyon kuralları
    /// </summary>
    public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage(OperationClaimMessages.NameIsRequired);
        }
    }
}
