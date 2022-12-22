using Application.Features.ProgrammingLanguageTechnologies.Constants;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{

    /// <summary>
    /// Programlama dili teknolojisi için sorgu sınıfı
    /// </summary>
    public class GetByIdProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyGetByIdDto>/*, ISecuredRequest*/
    {
        public int Id { get; set; }

    //    public string[] Roles { get; } =
    //    {
    //    ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyAdmin,
    //    ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyRead
    //};

        /// <summary>
        /// Programlama dili teknolojisi için işleyici sınıf
        /// </summary>
        public class GetByIdProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyGetByIdDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public GetByIdProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageLanguageTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
            {
                _programmingLanguageLanguageTechnologyRepository = programmingLanguageLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            }

            public async Task<ProgrammingLanguageTechnologyGetByIdDto> Handle(GetByIdProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                var programmingLanguageTechnology = await _programmingLanguageLanguageTechnologyRepository.Query().Include(x => x.ProgrammingLanguage).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                _programmingLanguageTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingLanguageTechnology);

                var programmingLanguageTechnologyGetByIdDto = _mapper.Map<ProgrammingLanguageTechnologyGetByIdDto>(programmingLanguageTechnology);
                return programmingLanguageTechnologyGetByIdDto;
            }
        }
    }
}
