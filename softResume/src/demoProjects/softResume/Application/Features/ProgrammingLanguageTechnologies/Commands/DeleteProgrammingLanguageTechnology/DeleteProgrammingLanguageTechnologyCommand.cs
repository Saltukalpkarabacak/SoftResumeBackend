﻿using Application.Features.ProgrammingLanguageTechnologies.Constants;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    /// <summary>
    /// Programlama dili teknolojisi silme komutu
    /// </summary>
    public class DeleteProgrammingLanguageTechnologyCommand : IRequest<DeletedProgrammingLanguageTechnologyDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyAdmin,
            ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyDelete,
            ProgrammingLanguageTechnologyRoles.Admin
        };

        /// <summary>
        /// Programlama Dili Teknolojisi Silmek için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommand, DeletedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageLanguageTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
            {
                _programmingLanguageLanguageTechnologyRepository = programmingLanguageLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageTechnologyDto> Handle(DeleteProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguageTechnology = await _programmingLanguageLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id);

                _programmingLanguageTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingLanguageTechnology);

                var deletedProgrammingLanguageTechnology = await _programmingLanguageLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnology);
                var mappedProgrammingLanguageTechnologyDto = _mapper.Map<DeletedProgrammingLanguageTechnologyDto>(deletedProgrammingLanguageTechnology);
                return mappedProgrammingLanguageTechnologyDto;
            }
        }
    }
}
