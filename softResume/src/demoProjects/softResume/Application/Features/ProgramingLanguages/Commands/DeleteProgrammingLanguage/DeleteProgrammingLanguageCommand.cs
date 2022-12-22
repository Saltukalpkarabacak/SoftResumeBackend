﻿using Application.Features.ProgramingLanguages.Dtos;
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

namespace Application.Features.ProgramingLanguages.Commands.DeleteProgrammingLanguage
{

    /// <summary>
    /// Programlama Dili silmek için kullanılan komut sınıfıdır.
    /// </summary>
    public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>/*, ISecuredRequest*/
    {
        public int Id { get; set; }
    //    public string[] Roles { get; } =
    //    {
    //    ProgrammingLanguageRoles.ProgrammingLanguageAdmin,
    //    ProgrammingLanguageRoles.ProgrammingLanguageDelete
    //};

        /// <summary>
        /// Programlama Dili Silmek için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageIdShouldBeExist(request.Id);

                var programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                var deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
                var mappedDeletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);
                return mappedDeletedProgrammingLanguageDto;
            }
        }
    }
}
