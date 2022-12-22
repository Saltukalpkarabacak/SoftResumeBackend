using Application.Features.UserOperationClaims.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim
{
    /// <summary>
    /// GetById Kullanıcı Operasyon İşlemi Validasyon Sınıfı
    /// </summary>
    public class GetByIdUserOperationClaimQueryValidator : AbstractValidator<GetByIdUserOperationClaimQuery>
    {
        public GetByIdUserOperationClaimQueryValidator()
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
