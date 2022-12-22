using Application.Features.ProgramingLanguages.Models;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Queries.GetListProgrammingLanguageByDynamic
{
    public class GetListProgrammingLanguageByDynamicQuery : IRequest<ProgrammingLanguageListModel>/*, ISecuredRequest*/
    {

        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

    //    public string[] Roles { get; } =
    //    {
    //    ProgrammingLanguageRoles.ProgrammingLanguageAdmin,
    //    ProgrammingLanguageRoles.ProgrammingLanguageRead
    //};

        /// <summary>
        /// Programlama dili için işleyici sınıfı
        /// </summary>
        public class GetListProgrammingLanguageByDynamicQueryHandler : IRequestHandler<GetListProgrammingLanguageByDynamicQuery, ProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageByDynamicQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageByDynamicQuery request, CancellationToken cancellationToken)
            {
                var models = await _programmingLanguageRepository.GetListByDynamicAsync(request.Dynamic, include:
                    m => m.Include(c => c.ProgrammingLanguageTechnologies),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);

                var mappedProgrammingLanguages = _mapper.Map<ProgrammingLanguageListModel>(models);
                return mappedProgrammingLanguages;
            }
        }

    }
}
