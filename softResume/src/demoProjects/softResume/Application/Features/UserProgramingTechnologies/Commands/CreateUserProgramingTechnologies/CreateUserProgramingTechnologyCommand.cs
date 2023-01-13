using Application.Features.UserProgramingTechnologies.Constants;
using Application.Features.UserProgramingTechnologies.Dtos;
using Application.Features.UserProgramingTechnologies.Rules;
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

namespace Application.Features.UserProgramingTechnologies.Commands.CreateUserProgramingTechnologies
{
    public class CreateUserProgramingTechnologyCommand:IRequest<CreatedUserProgramingTechnologyDto>/*,ISecuredRequest*/
    {
        public int UserId { get; set; }
        public int ProgramingTechnologyId { get; set; }
        //public string[] Roles { get; } =
        //{
        //    UserProgramingTechnologyRoles.Admin
        //};

        public class CreateUserProgramingTechnologyCommandHandler : IRequestHandler<CreateUserProgramingTechnologyCommand, CreatedUserProgramingTechnologyDto>
        {
            private readonly IUserProgramingTechnologyRepository _userProgramingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly UserProgramingTechnologyRules _userProgramingTechnologyRules;

            public CreateUserProgramingTechnologyCommandHandler(IUserProgramingTechnologyRepository userProgramingTechnologyRepository, IMapper mapper, UserProgramingTechnologyRules userProgramingTechnologyRules)
            {
                _userProgramingTechnologyRepository = userProgramingTechnologyRepository;
                _mapper = mapper;
                _userProgramingTechnologyRules = userProgramingTechnologyRules;
            }

            public async Task<CreatedUserProgramingTechnologyDto> Handle(CreateUserProgramingTechnologyCommand request, CancellationToken cancellationToken)
            {
                var mappedUserProgramingTechnology = _mapper.Map<UserProgramingTechnolgy>(request);
                var createdUserProgramingTechnology = await _userProgramingTechnologyRepository.AddAsync(mappedUserProgramingTechnology);
                var mappedCreatedUserProgramingTechnologyDto=_mapper.Map<CreatedUserProgramingTechnologyDto>(createdUserProgramingTechnology);
                return mappedCreatedUserProgramingTechnologyDto;
            }
        }
    }
}
