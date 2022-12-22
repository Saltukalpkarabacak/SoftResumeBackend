using Application.Features.ProgramingLanguages.Models;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgramingLanguages.Queries.GetListProgrammingLanguage
{
    /// <summary>
    /// Programlama dili için sorgu sınıfı
    /// </summary>
    public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        

        /// <summary>
        /// Programlama Dili Listelemek için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                var programmingLanguages = await _programmingLanguageRepository.GetListAsync(
                    include: m => m.Include(x => x.ProgrammingLanguageTechnologies),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);
                var programmingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);
                return programmingLanguageListModel;
            }
        }
    }
}
