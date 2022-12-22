using Application.Features.ProgramingLanguages.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.DeleteProgrammingLanguage
{
    /// <summary>
    /// Programlama dili silme komutu için validasyon sınıfıdır.
    /// </summary>
    public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageIdIsRequired);

            RuleFor(d => d.Id)
                .GreaterThan(0)
                .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageGreaterThanZero);
        }
    }
}
