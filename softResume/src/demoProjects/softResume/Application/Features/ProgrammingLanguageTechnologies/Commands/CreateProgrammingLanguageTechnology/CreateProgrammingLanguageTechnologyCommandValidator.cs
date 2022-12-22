using Application.Features.ProgrammingLanguageTechnologies.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    /// <summary>
    /// Programlama dili Teknolojisi İçin Validasyon Kuralları
    /// </summary>
    public class CreateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<CreateProgrammingLanguageTechnologyCommand>
    {
        public CreateProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageTechnologyMessages.NameIsRequired);

            RuleFor(p => p.ProgrammingLanguageId)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageIdIsRequired);

            RuleFor(d => d.ProgrammingLanguageId)
                .GreaterThan(0)
                .WithMessage(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageIdGreaterThanZero);
        }
    }
}
