using Application.Features.UserSocialMediaAddresses.Constants;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Rules;
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

namespace Application.Features.UserSocialMediaAddresses.Queries.GetByIdUserSocialMediaAddress
{
    /// <summary>
    /// İstenilen kullanıcı sosyal medya adresi isteği
    /// </summary>
    public class GetByIdUserSocialMediaAddressQuery : IRequest<UserSocialMediaAddressGetByIdDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
        UserSocialMediaAddressRoles.UserSocialMediaAddressAdmin,
        UserSocialMediaAddressRoles.UserSocialMediaAddressRead,
        UserSocialMediaAddressRoles.Admin
    };

        /// <summary>
        /// Kullanıcı Sosyal Medya Adresi Getirmek için işleyici sınıfı.
        /// </summary>
        public class GetByIdUserSocialMediaAddressQueryHandler : IRequestHandler<GetByIdUserSocialMediaAddressQuery, UserSocialMediaAddressGetByIdDto>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

            public GetByIdUserSocialMediaAddressQueryHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
                _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
            }

            public async Task<UserSocialMediaAddressGetByIdDto> Handle(GetByIdUserSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                var userSocialMediaAddress = await _userSocialMediaAddressRepository.Query().Include(x => x.User).FirstOrDefaultAsync(x =>
                    x.Id == request.Id,
                    cancellationToken: cancellationToken);

                _userSocialMediaAddressBusinessRules.SocialMediaAddressShouldExistWhenRequested(userSocialMediaAddress);

                var userSocialMediaAddressGetByIdDto = _mapper.Map<UserSocialMediaAddressGetByIdDto>(userSocialMediaAddress);
                return userSocialMediaAddressGetByIdDto;
            }
        }
    }
}
