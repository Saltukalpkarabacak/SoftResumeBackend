using Application.Features.ProgramingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgramingLanguages.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Programlama dili güncelleme komutu için validasyon sınıfıdır.
/// </summary>
public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
{
    public UpdateProgrammingLanguageCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageIdIsRequired);

        RuleFor(d => d.Id)
            .GreaterThan(0)
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageGreaterThanZero);

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageNameIsRequired);
    }
}
