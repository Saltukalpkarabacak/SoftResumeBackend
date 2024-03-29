﻿using Application.Features.UserSocialMediaAddresses.Constants;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Rules;
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

namespace Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress
{
    /// <summary>
    /// Güncellenecek Kullanıcı Sosyal Medya Adresinin İstek Komutudur.
    /// </summary>
    public class UpdateUserSocialMediaAddressCommand : IRequest<UpdatedUserSocialMediaAddressDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public string[] Roles { get; } =
        {
        UserSocialMediaAddressRoles.UserSocialMediaAddressAdmin,
        UserSocialMediaAddressRoles.UserSocialMediaAddressUpdate,
        UserSocialMediaAddressRoles.Admin
    };

        /// <summary>
        /// Güncellenecek Kullanıcı Sosyal Medya Adresinin İşleyici Sınıfıdır.
        /// </summary>
        public class UpdateUserSocialMediaAddressCommandHandler : IRequestHandler<UpdateUserSocialMediaAddressCommand, UpdatedUserSocialMediaAddressDto>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

            public UpdateUserSocialMediaAddressCommandHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
                _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
                // Added User Social Media Address Entity
            }

            public async Task<UpdatedUserSocialMediaAddressDto> Handle(UpdateUserSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                await _userSocialMediaAddressBusinessRules.UserSocialMediaAddressGithubUrlCanNotBeDuplicated(request.GithubUrl);

                var programmingTechnology = await _userSocialMediaAddressRepository.Query().AsNoTracking().FirstOrDefaultAsync(x =>
                        x.Id == request.Id,
                    cancellationToken: cancellationToken);

                await _userSocialMediaAddressBusinessRules.UserMustBeExist(request.UserId);
                _userSocialMediaAddressBusinessRules.SocialMediaAddressShouldExistWhenRequested(programmingTechnology);

                var mappedUserSocialMediaAddress = _mapper.Map<UserSocialMediaAddress>(request);
                var updatedUserSocialMediaAddress = await _userSocialMediaAddressRepository.UpdateAsync(mappedUserSocialMediaAddress);
                var mappedUpdatedUserSocialMediaAddressDto = _mapper.Map<UpdatedUserSocialMediaAddressDto>(updatedUserSocialMediaAddress);
                return mappedUpdatedUserSocialMediaAddressDto;
            }
        }
    }
}
