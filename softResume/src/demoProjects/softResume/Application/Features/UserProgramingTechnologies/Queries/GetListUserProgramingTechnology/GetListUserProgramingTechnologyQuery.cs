using Application.Features.UserProgramingTechnologies.Models;
using Application.Features.UserSocialMediaAddresses.Models;
using Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddress;
using Application.Services;
using AutoMapper;
using Core.Application.Requests;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Queries.GetListUserProgramingTechnology
{
    public class GetListUserProgramingTechnologyQuery : IRequest<UserProgramingTechnologyListModel>
    {

        public PageRequest PageRequest { get; set; }

        public class GetListUserProgramingTechnologyQueryHandler : IRequestHandler<GetListUserProgramingTechnologyQuery, UserProgramingTechnologyListModel>
        {
            private readonly IUserProgramingTechnologyRepository _userProgramingTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListUserProgramingTechnologyQueryHandler(IUserProgramingTechnologyRepository userProgramingTechnologyRepository, IMapper mapper)
            {
                _userProgramingTechnologyRepository = userProgramingTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UserProgramingTechnologyListModel> Handle(GetListUserProgramingTechnologyQuery request, CancellationToken cancellationToken)
            {
                var userProgramingTechnolgy = await _userProgramingTechnologyRepository.GetListAsync(include: m =>
                        m.Include(c => c.User).Include(c => c.ProgrammingLanguageTechnology),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);

                var userProgramingTechnologyListModel = _mapper.Map<UserProgramingTechnologyListModel>(userProgramingTechnolgy);
                return userProgramingTechnologyListModel;
            }
        }

    }
}
