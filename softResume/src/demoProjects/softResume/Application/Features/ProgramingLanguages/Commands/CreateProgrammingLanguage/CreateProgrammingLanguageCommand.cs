using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Features.ProgramingLanguages.Constants;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMediaAddresses.Constants;

namespace Application.Features.ProgramingLanguages.Commands.CreateProgrammingLanguage
{
    /// <summary>
    /// Programlama Dili eklemek için kullanılan komut sınıfıdır.
    /// </summary>
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>,ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles { get; } =
   {
        ProgrammingLanguageRoles.ProgrammingLanguageAdmin,
        ProgrammingLanguageRoles.ProgrammingLanguageCreate,
        ProgrammingLanguageRoles.Admin
    };


        /// <summary>
        /// Programlama Dili Eklemek için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicated(request.Name);

                ProgrammingLanguage mappedPrgramingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdPrgramingLanguage = await _programmingLanguageRepository.AddAsync(mappedPrgramingLanguage);
                CreatedProgrammingLanguageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdPrgramingLanguage);

                return createdProgrammingLanguageDto;
            }
        }
    }
}
