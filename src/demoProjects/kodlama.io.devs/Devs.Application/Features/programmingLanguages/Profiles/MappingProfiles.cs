using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.programmingLanguages.Commands.CreateProgrammingLanguage;
using Devs.Application.Features.programmingLanguages.Commands.DeleteProgrammingLanguage;
using Devs.Application.Features.programmingLanguages.Commands.UpdateProgrammingLanguage;
using Devs.Application.Features.programmingLanguages.Dtos.ProgrammingLanguageDtos;
using Devs.Application.Features.programmingLanguages.Models;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.programmingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguageEntity, CreatedProgrammingLanguageEntityDto>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, CreateProgrammingLanguageEntityCommand>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, ProgrammingLanguageEntityListDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguageEntity>, ProgramminLanguageEntityListModel>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguageEntity>, ProgrammingLanguageEntityGetByIdDto>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, UpdatedProgrammingLanguageEntityDto>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, UpdateProgrammingLanguageEntityCommand>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, DeletedProgrammingLanguageEntityDto>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, DeleteProgrammingLanguageEntityCommand>().ReverseMap();
        }
    }
}
