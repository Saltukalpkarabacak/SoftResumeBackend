using Application.Features.ProgramingLanguages.Constants;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
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

namespace Application.Features.ProgramingLanguages.Queries.GetByIdProgrammingLanguage
{
    /// <summary>
    /// Programlama dili için sorgu sınıfı
    /// </summary>
    public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageGetByIdDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
        ProgrammingLanguageRoles.ProgrammingLanguageAdmin,
        ProgrammingLanguageRoles.ProgrammingLanguageRead,
        ProgrammingLanguageRoles.Admin
    };

        /// <summary>
        /// Programlama Dili Getirmek için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;


            public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                var programmingLanguage = await _programmingLanguageRepository.Query().Include(x => x.ProgrammingLanguageTechnologies).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

                var mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);
                return mappedProgrammingLanguage;
            }
        }
    }
}
