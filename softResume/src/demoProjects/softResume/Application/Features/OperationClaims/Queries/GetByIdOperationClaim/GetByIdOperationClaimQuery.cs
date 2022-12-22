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

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{

    /// <summary>
    /// Operasyon Claim için sorgu sınıfı
    /// </summary>
    public class GetByIdOperationClaimQuery : IRequest<OperationClaimGetByIdDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
        OperationClaimRoles.OperationClaimAdmin,
        OperationClaimRoles.OperationClaimRead,
        OperationClaimRoles.Admin
    };

        /// <summary>
        /// Operasyon Claim Getirmek için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, OperationClaimGetByIdDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<OperationClaimGetByIdDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimIdShouldBeExist(request.Id);

                var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
                var mappedOperationClaim = _mapper.Map<OperationClaimGetByIdDto>(operationClaim);
                return mappedOperationClaim;
            }
        }
    }
}
