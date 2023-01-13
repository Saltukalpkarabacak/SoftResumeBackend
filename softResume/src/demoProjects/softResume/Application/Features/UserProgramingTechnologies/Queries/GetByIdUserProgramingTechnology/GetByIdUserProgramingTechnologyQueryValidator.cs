using Application.Features.UserProgramingTechnologies.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Queries.GetByIdUserProgramingTechnology
{
    public class GetByIdUserProgramingTechnologyQueryValidator : AbstractValidator<GetByIdUserProgramingTechnologyQuery>
    {
        public GetByIdUserProgramingTechnologyQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserProgramingTechnologyMessages.IdIsRequired);

            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage(UserProgramingTechnologyMessages.GreaterThanZero);
        }
    }
}
