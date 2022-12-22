using Application.Features.UserSocialMediaAddresses.Constants;
using Application.Features.UserSocialMediaAddresses.Models;
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

namespace Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddress
{

    /// <summary>
    /// Tüm kullanıcıların sosyal medya adresi isteği
    /// </summary>
    public class GetListUserSocialMediaAddressQuery : IRequest<UserSocialMediaAddressListModel>/*, ISecuredRequest*/
    {
        public PageRequest PageRequest { get; set; }

        //    public string[] Roles { get; } =
        //    {
        //    UserSocialMediaAddressRoles.UserSocialMediaAddressAdmin,
        //    UserSocialMediaAddressRoles.UserSocialMediaAddressRead
        //};


        /// <summary>
        /// Tüm Kullanıcıların sosyal medya adresini getirmek için işleyici sınıfı.
        /// </summary>
        public class GetListUserSocialMediaAddressQueryHandler : IRequestHandler<GetListUserSocialMediaAddressQuery, UserSocialMediaAddressListModel>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;

            public GetListUserSocialMediaAddressQueryHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<UserSocialMediaAddressListModel> Handle(GetListUserSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                var userSocialMediaAddresses = await _userSocialMediaAddressRepository.GetListAsync(include: m =>
                        m.Include(c => c.User),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);

                var userSocialMediaAddressListModel = _mapper.Map<UserSocialMediaAddressListModel>(userSocialMediaAddresses);
                return userSocialMediaAddressListModel;
            }
        }
    }
}
