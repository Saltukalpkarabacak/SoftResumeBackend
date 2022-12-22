using Application.Features.ProgramingLanguages.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.CreateProgrammingLanguage
{
    /// <summary>
    /// Programlama dili oluşturma komutu için validasyon sınıfıdır.
    /// </summary>
    public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageNameIsRequired);
        }
    }
}
