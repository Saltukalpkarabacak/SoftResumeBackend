using Application.Features.UserSocialMediaAddresses.Constants;
using Application.Features.UserSocialMediaAddresses.Models;
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

namespace Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddressByDynamic
{
    /// <summary>
    /// Tüm kullanıcıların sosyal medya adresi isteği
    /// </summary>
    public class GetListUserSocialMediaAddressByDynamicQuery : IRequest<UserSocialMediaAddressListModel>/*, ISecuredRequest*/
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
    //    public string[] Roles { get; } =
    //    {
    //    UserSocialMediaAddressRoles.UserSocialMediaAddressAdmin,
    //    UserSocialMediaAddressRoles.UserSocialMediaAddressRead
    //};

        /// <summary>
        /// Tüm kullanıcıların sosyal medya adresi için işleyici sınıfı
        /// </summary>
        public class GetListUserSocialMediaAddressByDynamicQueryHandler : IRequestHandler<GetListUserSocialMediaAddressByDynamicQuery, UserSocialMediaAddressListModel>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;

            public GetListUserSocialMediaAddressByDynamicQueryHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<UserSocialMediaAddressListModel> Handle(GetListUserSocialMediaAddressByDynamicQuery request, CancellationToken cancellationToken)
            {
                var userSocialMediaAddresses = await _userSocialMediaAddressRepository.GetListByDynamicAsync(request.Dynamic, include:
                    m => m.Include(c => c.User),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);

                var mappedSocialMediaAddressListModel = _mapper.Map<UserSocialMediaAddressListModel>(userSocialMediaAddresses);
                return mappedSocialMediaAddressListModel;
            }
        }
    }
}
