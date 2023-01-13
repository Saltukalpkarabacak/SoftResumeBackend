using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.UserProgramingTechnologies.Constants;
using Application.Features.UserProgramingTechnologies.Dtos;
using Application.Features.UserProgramingTechnologies.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Commands.UpdateUserProgramingTechnologies
{
    public class UpdateUserProgramingTechnologiesCommand:IRequest<UpdatedUserProgramingTechnologyDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProgramingTechnologyId { get; set; }
        public string[] Roles { get; } =
        {
            UserProgramingTechnologyRoles.Admin
        };

        public class UpdateUserProgramingTechnologiesCommandHandler : IRequestHandler<UpdateUserProgramingTechnologiesCommand, UpdatedUserProgramingTechnologyDto>
        {
            private readonly IUserProgramingTechnologyRepository _userProgramingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly UserProgramingTechnologyRules _userProgramingTechnologyRules;

            public UpdateUserProgramingTechnologiesCommandHandler(IUserProgramingTechnologyRepository userProgramingTechnologyRepository, IMapper mapper, UserProgramingTechnologyRules userProgramingTechnologyRules)
            {
                _userProgramingTechnologyRepository = userProgramingTechnologyRepository;
                _mapper = mapper;
                _userProgramingTechnologyRules = userProgramingTechnologyRules;
            }

            public async Task<UpdatedUserProgramingTechnologyDto> Handle(UpdateUserProgramingTechnologiesCommand request, CancellationToken cancellationToken)
            {
                var userprogramingTechnology = await _userProgramingTechnologyRepository.Query().AsNoTracking().FirstOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken: cancellationToken);

                var mappedUserProgramingTechnology = _mapper.Map<UserProgramingTechnolgy>(request);
                var updatedUserProgramingTechnology = await _userProgramingTechnologyRepository.UpdateAsync(mappedUserProgramingTechnology);
                var mappedUserProgramingTechnologyDto=_mapper.Map<UpdatedUserProgramingTechnologyDto>(updatedUserProgramingTechnology);
                return mappedUserProgramingTechnologyDto;
            }
        }
    }
}
