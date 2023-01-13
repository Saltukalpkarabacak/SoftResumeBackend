using Application.Features.UserProgramingTechnologies.Constants;
using Application.Features.UserProgramingTechnologies.Dtos;
using Application.Features.UserProgramingTechnologies.Rules;
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

namespace Application.Features.UserProgramingTechnologies.Queries.GetByIdUserProgramingTechnology
{
    public class GetByIdUserProgramingTechnologyQuery : IRequest<UserProgramingTechnologyGetByIdDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            UserProgramingTechnologyRoles.Admin
        };

        public class GetByIdUserProgramingTechnologyQueryHandler : IRequestHandler<GetByIdUserProgramingTechnologyQuery, UserProgramingTechnologyGetByIdDto>
        {
            private readonly IUserProgramingTechnologyRepository _userProgramingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly UserProgramingTechnologyRules _userProgramingTechnologyRules;

            public GetByIdUserProgramingTechnologyQueryHandler(IUserProgramingTechnologyRepository userProgramingTechnologyRepository, IMapper mapper, UserProgramingTechnologyRules userProgramingTechnologyRules)
            {
                _userProgramingTechnologyRepository = userProgramingTechnologyRepository;
                _mapper = mapper;
                _userProgramingTechnologyRules = userProgramingTechnologyRules;
            }

            public async Task<UserProgramingTechnologyGetByIdDto> Handle(GetByIdUserProgramingTechnologyQuery request, CancellationToken cancellationToken)
            {
                var userProgramingTechnology = await _userProgramingTechnologyRepository.Query()
               .Include(x => x.User).Include(c => c.ProgrammingLanguageTechnology)
               .FirstOrDefaultAsync(x =>
                x.Id == request.Id,
                cancellationToken:cancellationToken);

                var userProgramingTechnologyGetByIdDto = _mapper.Map<UserProgramingTechnologyGetByIdDto>(userProgramingTechnology);
                return userProgramingTechnologyGetByIdDto;  
            }
        }

    }
}
