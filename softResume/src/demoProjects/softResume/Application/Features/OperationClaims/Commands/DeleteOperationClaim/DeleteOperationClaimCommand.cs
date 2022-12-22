using Application.Features.OperationClaims.Constants;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    /// <summary>
    /// Operasyon claim silme komutu
    /// </summary>
    public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
        OperationClaimRoles.OperationClaimAdmin,
        OperationClaimRoles.OperationClaimDelete,
        OperationClaimRoles.Admin
    };

        /// <summary>
        /// Operasyon claim silme işleyicisi
        /// </summary>
        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
            private readonly IMapper _mapper;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimIdShouldBeExist(request.Id);

                var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
                var deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaim);
                var mappedOperationClaim = _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);
                return mappedOperationClaim;
            }
        }
    }
}
