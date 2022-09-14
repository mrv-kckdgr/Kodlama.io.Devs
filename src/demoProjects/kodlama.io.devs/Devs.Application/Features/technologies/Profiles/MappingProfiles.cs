using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.programmingLanguages.Dtos.ProgrammingLanguageDtos;
using Devs.Application.Features.programmingLanguages.Models;
using Devs.Application.Features.technologies.Commands.CreateTechnology;
using Devs.Application.Features.technologies.Commands.DeleteTechnology;
using Devs.Application.Features.technologies.Commands.UpdateTechnology;
using Devs.Application.Features.technologies.Dtos.TechnologyDtos;
using Devs.Application.Features.technologies.Models;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TechnologyEntity, CreatedTechnologyEntityDto>().ReverseMap();
            CreateMap<TechnologyEntity, CreateTechnologyEntityCommand>().ReverseMap();

            CreateMap<TechnologyEntity, UpdatedTechnologyEntityDto>().ReverseMap();
            CreateMap<TechnologyEntity, UpdateTechnologyEntityCommand>().ReverseMap();

            CreateMap<TechnologyEntity, DeletedTechnologyEntityDto>().ReverseMap();
            CreateMap<TechnologyEntity, DeleteTechnologyEntityCommand>().ReverseMap();

            CreateMap<TechnologyEntity, TechnologyEntityListDto>().ForMember(x => x.ProgrammingLanguageName, 
                opt => opt.MapFrom(x => 
                                    x.ProgrammingLanguage.Name)).ReverseMap();  
            
            CreateMap<IPaginate<TechnologyEntity>, TechnologyEntityGetByIdDto>().ReverseMap();

            CreateMap<IPaginate<TechnologyEntity>, TechnologyEntityListModel>().ReverseMap();
        }
    }
}
