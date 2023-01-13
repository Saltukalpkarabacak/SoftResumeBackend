using Application.Features.UserProgramingTechnologies.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Commands.DeleteUserProgramingTechnologies
{
    public class DeleteUserProgramingTechnologyCommandValidator:AbstractValidator<DeleteUserProgramingTechnologyCommand>
    {
        public DeleteUserProgramingTechnologyCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserProgramingTechnologyMessages.IdIsRequired);


        }
    }
}
