﻿using Application.Features.ProgrammingLanguageTechnologies.Constants;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
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

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    /// <summary>
    /// Programlama dili Teknolojisi Oluşturma Komutu
    /// </summary>
    public class CreateProgrammingLanguageTechnologyCommand : IRequest<CreatedProgrammingLanguageTechnologyDto>, ISecuredRequest
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string[] Roles { get; } =
        {
        ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyAdmin,
        ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyCreate,
        ProgrammingLanguageTechnologyRoles.Admin
    };

        /// <summary>
        /// Programlama dili teknolojisi oluşturmak için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommand, CreatedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public CreateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageLanguageTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
            {
                _programmingLanguageLanguageTechnologyRepository = programmingLanguageLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            }

            public async Task<CreatedProgrammingLanguageTechnologyDto> Handle(CreateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicated(request.Name);

                var mappedProgrammingTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
                var createdProgrammingTechnology = await _programmingLanguageLanguageTechnologyRepository.AddAsync(mappedProgrammingTechnology);
                var mappedCreatedProgrammingTechnologyDto = _mapper.Map<CreatedProgrammingLanguageTechnologyDto>(createdProgrammingTechnology);
                return mappedCreatedProgrammingTechnologyDto;
            }
        }
    }
}
