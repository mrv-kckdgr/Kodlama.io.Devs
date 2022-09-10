using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.programmingLanguages.Dtos.ProgrammingLanguageDtos;
using Devs.Application.Features.programmingLanguages.Models;
using Devs.Application.Features.programmingLanguages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.programmingLanguages.Queries.GeListProgrammingLanguageEntity
{
    public class GetListProgrammingLanguageEntityQuery : IRequest<ProgramminLanguageEntityListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgrammingLanguageEntityQueryHandler : IRequestHandler<GetListProgrammingLanguageEntityQuery, ProgramminLanguageEntityListModel>
        {
            private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;
            private readonly IMapper _mapper;            

            public GetListProgrammingLanguageEntityQueryHandler(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository, IMapper mapper, ProgrammingLanguageEntityBusinessRules programmingLanguageEntityBusinessRules)
            {
                _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
                _mapper = mapper;                
            }

            public async Task<ProgramminLanguageEntityListModel> Handle(GetListProgrammingLanguageEntityQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageEntity> programmingLanguages = await _programmingLanguageEntityRepository.GetListAsync(
                    index: request.PageRequest.Page, 
                    size: request.PageRequest.PageSize);

                ProgramminLanguageEntityListModel programmingLanguageEntityGetByIdDto = _mapper.Map<ProgramminLanguageEntityListModel>(programmingLanguages);
                return programmingLanguageEntityGetByIdDto;
            }          
        }
    }
}
