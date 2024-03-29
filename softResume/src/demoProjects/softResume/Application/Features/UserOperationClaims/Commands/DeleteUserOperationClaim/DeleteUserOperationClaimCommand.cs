﻿using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    /// <summary>
    /// Kullanıcı Operasyon claim silme komutu
    /// </summary>
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
        UserOperationClaimRoles.UserOperationClaimAdmin,
        UserOperationClaimRoles.UserOperationClaimDelete,
        UserOperationClaimRoles.Admin
    };

        /// <summary>
        /// Kullanıcı Operasyon claim silme işleyicisi
        /// </summary>
        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IMapper _mapper;

            public DeleteOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserOperationClaimIdShouldBeExist(request.Id);

                var userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.Id == request.Id);
                var deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);
                var mappedUserOperationClaim = _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
                return mappedUserOperationClaim;
            }
        }
    }
}
