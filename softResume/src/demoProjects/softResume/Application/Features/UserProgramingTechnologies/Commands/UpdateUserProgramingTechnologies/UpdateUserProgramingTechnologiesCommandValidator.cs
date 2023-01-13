using Application.Features.UserProgramingTechnologies.Constants;
using Application.Features.UserSocialMediaAddresses.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Commands.UpdateUserProgramingTechnologies
{
    public class UpdateUserProgramingTechnologiesCommandValidator:AbstractValidator<UpdateUserProgramingTechnologiesCommand>
    {
        public UpdateUserProgramingTechnologiesCommandValidator()
        {
            RuleFor(p => p.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserSocialMediaAddressMessages.IdIsRequired);

            RuleFor(p => p.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaAddressMessages.UserIdIsRequired);

            RuleFor(p => p.ProgramingTechnologyId)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserProgramingTechnologyMessages.ProgramingTechnologylIsRequired);
        }
    }
}
