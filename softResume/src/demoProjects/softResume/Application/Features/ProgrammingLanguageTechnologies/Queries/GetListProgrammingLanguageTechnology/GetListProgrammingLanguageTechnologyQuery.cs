using Application.Features.ProgrammingLanguageTechnologies.Constants;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{

    /// <summary>
    /// Programlama dili teknolojisi için sorgu sınıfı
    /// </summary>
    public class GetListProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
        ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyAdmin,
        ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyRead,
        ProgrammingLanguageTechnologyRoles.Admin
    };

        /// <summary>
        /// Programlama teknolojisi için işleyici sınıfı
        /// </summary>
        public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageLanguageTechnologyRepository = programmingLanguageLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                var programmingLanguageTechnologies = await _programmingLanguageLanguageTechnologyRepository.GetListAsync(include: m =>
                    m.Include(c => c.ProgrammingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);

                var programmingLanguageTechnologyListModel = _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);
                return programmingLanguageTechnologyListModel;
            }
        }
    }
}
