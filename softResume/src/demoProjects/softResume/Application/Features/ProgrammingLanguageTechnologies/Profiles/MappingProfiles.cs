using Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Profiles
{

    /// <summary>
    /// Programlama teknolojisi varlığı için AutoMapper profili.
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguageTechnology, CreatedProgrammingLanguageTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommand>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, DeleteProgrammingLanguageTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, DeletedProgrammingLanguageTechnologyDto>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, UpdateProgrammingLanguageTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, UpdatedProgrammingLanguageTechnologyDto>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologyListModel>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyListDto>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyGetByIdDto>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyListDto>()
                .ForMember(c => c.ProgrammingLanguageName,
                    opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologyListModel>().ReverseMap();
        }
    }
}
