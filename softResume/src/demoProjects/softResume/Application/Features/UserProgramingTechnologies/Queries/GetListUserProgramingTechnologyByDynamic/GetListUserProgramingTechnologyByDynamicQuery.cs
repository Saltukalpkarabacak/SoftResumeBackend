using Application.Features.UserProgramingTechnologies.Constants;
using Application.Features.UserProgramingTechnologies.Models;
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

namespace Application.Features.UserProgramingTechnologies.Queries.GetListUserProgramingTechnologyByDynamic
{
    public class GetListUserProgramingTechnologyByDynamicQuery : IRequest<UserProgramingTechnologyListModel>, ISecuredRequest
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
            UserProgramingTechnologyRoles.Admin
        };

        public class GetListUserProgramingTechnologyByDynamicQueryHandler: IRequestHandler<GetListUserProgramingTechnologyByDynamicQuery, UserProgramingTechnologyListModel>
        {
            private readonly IUserProgramingTechnologyRepository _userProgramingTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListUserProgramingTechnologyByDynamicQueryHandler(IUserProgramingTechnologyRepository userProgramingTechnologyRepository, IMapper mapper)
            {
                _userProgramingTechnologyRepository = userProgramingTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UserProgramingTechnologyListModel> Handle(GetListUserProgramingTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                var userProgramingTechnology = await _userProgramingTechnologyRepository.GetListByDynamicAsync(request.Dynamic,include:
                    m => m.Include(c => c.User),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

                var mappedUserProgramingTechnologyListModel = _mapper.Map<UserProgramingTechnologyListModel>(userProgramingTechnology); 
                return mappedUserProgramingTechnologyListModel; 
            }
        }


    }
}
