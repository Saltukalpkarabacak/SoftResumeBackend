using Application.Features.ProgramingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Profiles
{

    /// <summary>
    /// Programlama dili varlığı için AutoMapper profili.
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>()
                .ForMember(c => c.ProgrammingTechnologies,
                    opt => opt.MapFrom(c => c.ProgrammingLanguageTechnologies))
                .ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();

            //added dynamict list and paging
        }
    }
}
