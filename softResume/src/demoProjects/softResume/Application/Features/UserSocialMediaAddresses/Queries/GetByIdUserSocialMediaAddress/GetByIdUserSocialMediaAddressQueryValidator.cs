using Application.Features.UserSocialMediaAddresses.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Queries.GetByIdUserSocialMediaAddress
{
    /// <summary>
    /// 
    /// </summary>
    public class GetByIdUserSocialMediaAddressQueryValidator : AbstractValidator<GetByIdUserSocialMediaAddressQuery>
    {
        public GetByIdUserSocialMediaAddressQueryValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaAddressMessages.IdIsRequired);

            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage(UserSocialMediaAddressMessages.GreaterThanZero);
        }
    }
}
