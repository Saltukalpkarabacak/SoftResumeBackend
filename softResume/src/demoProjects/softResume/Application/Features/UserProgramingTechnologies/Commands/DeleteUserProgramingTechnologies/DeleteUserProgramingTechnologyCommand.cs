using Application.Features.UserProgramingTechnologies.Constants;
using Application.Features.UserProgramingTechnologies.Dtos;
using Application.Features.UserProgramingTechnologies.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Commands.DeleteUserProgramingTechnologies
{
    public class DeleteUserProgramingTechnologyCommand:IRequest<DeletedUserProgramingTechnologyDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            UserProgramingTechnologyRoles.Admin
        };

        public class DeleteUserProgramingTechnologyCommandHandler : IRequestHandler<DeleteUserProgramingTechnologyCommand, DeletedUserProgramingTechnologyDto>
        {
            private readonly IUserProgramingTechnologyRepository _userProgramingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly UserProgramingTechnologyRules _userProgramingTechnologyRules;

            public DeleteUserProgramingTechnologyCommandHandler(IUserProgramingTechnologyRepository userProgramingTechnologyRepository, IMapper mapper, UserProgramingTechnologyRules userProgramingTechnologyRules)
            {
                _userProgramingTechnologyRepository = userProgramingTechnologyRepository;
                _mapper = mapper;
                _userProgramingTechnologyRules = userProgramingTechnologyRules;
            }

            public async Task<DeletedUserProgramingTechnologyDto> Handle(DeleteUserProgramingTechnologyCommand request, CancellationToken cancellationToken)
            {
                var userProgramingTechnology = await _userProgramingTechnologyRepository.GetAsync(x => x.Id==request.Id);
                var deletedUserProgramingTechnology = await _userProgramingTechnologyRepository.DeleteAsync(userProgramingTechnology);
                var mappedDeletedUserProgramingTechnologyDto = _mapper.Map<DeletedUserProgramingTechnologyDto>(deletedUserProgramingTechnology);
                return mappedDeletedUserProgramingTechnologyDto;
            
            }
        }
    }
}
