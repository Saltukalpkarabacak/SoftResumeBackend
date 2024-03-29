﻿using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Models;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    /// <summary>
    /// Kullanıcı Operasyon Claim için sorgu sınıfı
    /// </summary>
    public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
        UserOperationClaimRoles.UserOperationClaimAdmin,
        UserOperationClaimRoles.UserOperationClaimRead,
        UserOperationClaimRoles.Admin
    };

        /// <summary>
        /// Kullanıcı Operasyon Claim Listelemek için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                var userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include:
                    m => m.Include(c => c.User).Include(x => x.OperationClaim),
                    cancellationToken: cancellationToken);

                var userOperationClaimListModel = _mapper.Map<UserOperationClaimListModel>(userOperationClaims);
                return userOperationClaimListModel;
            }
        }
    }
}
