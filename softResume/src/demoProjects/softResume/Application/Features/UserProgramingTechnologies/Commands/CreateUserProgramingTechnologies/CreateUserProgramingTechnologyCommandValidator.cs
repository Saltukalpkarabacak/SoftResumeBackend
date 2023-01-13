using Application.Features.UserProgramingTechnologies.Constants;
using Application.Features.UserSocialMediaAddresses.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Commands.CreateUserProgramingTechnologies
{
    public class CreateUserProgramingTechnologyCommandValidator : AbstractValidator<CreateUserProgramingTechnologyCommand>
    {
        public CreateUserProgramingTechnologyCommandValidator()
        {
            RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserProgramingTechnologyMessages.UserIdIsRequired);

            RuleFor(x => x.ProgramingTechnologyId)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserProgramingTechnologyMessages.ProgramingTechnologylIsRequired);
        }
    }
}
