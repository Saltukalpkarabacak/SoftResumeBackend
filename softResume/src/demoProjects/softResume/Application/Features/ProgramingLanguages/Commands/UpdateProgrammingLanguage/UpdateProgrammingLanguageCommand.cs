using Application.Features.ProgramingLanguages.Constants;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.UpdateProgrammingLanguage
{

    /// <summary>
    /// Programlama Dili güncellemek için kullanılan komut sınıfıdır.
    /// </summary>
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles { get; } =
        {
        ProgrammingLanguageRoles.ProgrammingLanguageAdmin,
        ProgrammingLanguageRoles.ProgrammingLanguageUpdate,
        ProgrammingLanguageRoles.Admin
    };

        /// <summary>
        /// Programlama Dili Güncellemek için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageIdShouldBeExist(request.Id);
                await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicated(request.Name);

                var programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);

                var mappedProgrammingLanguage = _mapper.Map(request, programmingLanguage);
                var updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);
                var mappedUpdatedProgrammingLanguage = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);
                return mappedUpdatedProgrammingLanguage;
            }
        }
    }
}
