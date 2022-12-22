using Application.Features.ProgrammingLanguageTechnologies.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{
    /// <summary>
    /// Programlama dili teknolojisi get by id komutu için validasyon sınıfıdır.
    /// </summary>
    public class GetByIdProgrammingLanguageTechnologyQueryValidator : AbstractValidator<GetByIdProgrammingLanguageTechnologyQuery>
    {
        public GetByIdProgrammingLanguageTechnologyQueryValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageTechnologyMessages.IdIsRequired);

            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage(ProgrammingLanguageTechnologyMessages.GreaterThanZero);
        }
    }
}
