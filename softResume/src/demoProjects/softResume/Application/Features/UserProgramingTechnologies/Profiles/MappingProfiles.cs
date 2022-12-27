using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Features.UserProgramingTechnologies.Dtos;
using Application.Features.UserProgramingTechnologies.Models;
using Application.Features.UserSocialMediaAddresses.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<UserProgramingTechnolgy>, User>().ReverseMap();
            CreateMap<IPaginate<UserProgramingTechnolgy>, ProgrammingLanguageTechnology>().ReverseMap();
            CreateMap<IPaginate<UserProgramingTechnolgy>, UserProgramingTechnologyListModel>().ReverseMap();
            CreateMap<UserProgramingTechnolgy, UserProgramingTechnologyListDto>()
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
                        opt.MapFrom(c => c.User.Email))
            .ForMember(c =>
                        c.Name,
                    opt =>
                        opt.MapFrom(c => c.ProgrammingLanguageTechnology.Name))
                .ReverseMap();
        }
    }
}
