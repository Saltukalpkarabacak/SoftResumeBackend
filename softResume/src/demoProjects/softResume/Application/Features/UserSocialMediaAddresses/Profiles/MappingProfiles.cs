using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Profiles
{
    /// <summary>
    /// Kullanıcı Sosyal Medya Adres varlığı için AutoMapper profili.
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserSocialMediaAddress, CreatedUserSocialMediaAddressDto>().ReverseMap();
            CreateMap<UserSocialMediaAddress, CreateUserSocialMediaAddressCommand>().ReverseMap();

            CreateMap<UserSocialMediaAddress, DeleteUserSocialMediaAddressCommand>().ReverseMap();
            CreateMap<UserSocialMediaAddress, DeletedUserSocialMediaAddressDto>().ReverseMap();

            CreateMap<UserSocialMediaAddress, UpdateUserSocialMediaAddressCommand>().ReverseMap();
            CreateMap<UserSocialMediaAddress, UpdatedUserSocialMediaAddressDto>().ReverseMap();

            CreateMap<IPaginate<UserSocialMediaAddress>, UserSocialMediaAddressListModel>().ReverseMap();
            CreateMap<UserSocialMediaAddress, UserSocialMediaAddressListDto>().ReverseMap();

            CreateMap<UserSocialMediaAddress, UserSocialMediaAddressGetByIdDto>()
                .ForMember(c =>
                        c.FirstName,
                    opt =>
                        opt.MapFrom(c => c.User.FirstName))
                .ForMember(c =>
                        c.LastName,
                    opt =>
                        opt.MapFrom(c => c.User.LastName))
                .ForMember(c =>
                        c.Email,
                    opt =>
                        opt.MapFrom(c => c.User.Email)).ReverseMap();

            CreateMap<UserSocialMediaAddress, UserSocialMediaAddressListDto>()
                .ForMember(c =>
                        c.FirstName,
                    opt =>
                        opt.MapFrom(c => c.User.FirstName))
                .ForMember(c =>
                        c.LastName,
                    opt =>
                        opt.MapFrom(c => c.User.LastName))
                .ForMember(c =>
                        c.Email,
                    opt =>
                        opt.MapFrom(c => c.User.Email)).ReverseMap();


            CreateMap<IPaginate<UserSocialMediaAddress>, ProgrammingLanguageTechnologyListModel>().ReverseMap();
        }
    }
}
