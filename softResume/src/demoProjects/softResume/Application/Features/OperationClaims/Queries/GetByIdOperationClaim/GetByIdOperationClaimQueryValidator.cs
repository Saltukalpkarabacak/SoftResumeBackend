using Application.Features.OperationClaims.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    /// <summary>
    /// Operasyon Claim GetById için validasyon sınıfı
    /// </summary>
    public class GetByIdOperationClaimQueryValidator : AbstractValidator<GetByIdOperationClaimQuery>
    {
        public GetByIdOperationClaimQueryValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage(OperationClaimMessages.IdIsRequired);

            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage(OperationClaimMessages.GreaterThanZero);
        }
    }
}
