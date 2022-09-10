using AutoMapper;
using Devs.Application.Features.programmingLanguages.Dtos.ProgrammingLanguageDtos;
using Devs.Application.Features.programmingLanguages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.programmingLanguages.Queries.GetByIdProgrammingLanguageEntity
{
    public class GetByIdProgrammingLanguageEntityQuery : IRequest<ProgrammingLanguageEntityGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProgrammingLanguageEntityQueryHandler : IRequestHandler<GetByIdProgrammingLanguageEntityQuery, ProgrammingLanguageEntityGetByIdDto>
        {
            private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageEntityBusinessRules _programmingLanguageEntityBusinessRules;

            public GetByIdProgrammingLanguageEntityQueryHandler(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository, IMapper mapper, ProgrammingLanguageEntityBusinessRules programmingLanguageEntityBusinessRules)
            {
                _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
                _mapper = mapper;
                _programmingLanguageEntityBusinessRules = programmingLanguageEntityBusinessRules;
            }

            public async Task<ProgrammingLanguageEntityGetByIdDto> Handle(GetByIdProgrammingLanguageEntityQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageEntity? programmingLanguageEntity = await _programmingLanguageEntityRepository.GetAsync(x => x.Id == request.Id);

                _programmingLanguageEntityBusinessRules.ProgrammingLanguageEntityShouldExistsWhenRequested(programmingLanguageEntity);

                ProgrammingLanguageEntityGetByIdDto programmingLanguageEntityGetByIdDto = _mapper.Map<ProgrammingLanguageEntityGetByIdDto>(programmingLanguageEntity);

                return programmingLanguageEntityGetByIdDto;
            }
        }
    }
}
