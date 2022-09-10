﻿using AutoMapper;
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

namespace Devs.Application.Features.programmingLanguages.Commands.CreateProgrammingLanguage
{
    public partial class CreateProgrammingLanguageEntityCommand : IRequest<CreatedProgrammingLanguageEntityDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageEntityCommandHandler : IRequestHandler<CreateProgrammingLanguageEntityCommand, CreatedProgrammingLanguageEntityDto>
        {
            private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageEntityBusinessRules _programmingLanguageEntityBusinessRules;

            public CreateProgrammingLanguageEntityCommandHandler(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository, IMapper mapper, ProgrammingLanguageEntityBusinessRules programmingLanguageEntityBusinessRules)
            {
                _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
                _mapper = mapper;
                _programmingLanguageEntityBusinessRules = programmingLanguageEntityBusinessRules;
            }

            public async Task<CreatedProgrammingLanguageEntityDto> Handle(CreateProgrammingLanguageEntityCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageEntityBusinessRules.ProgrammingLanguageEntityNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguageEntity mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguageEntity>(request);
                ProgrammingLanguageEntity createdProgrammingLanguage = await _programmingLanguageEntityRepository.AddAsync(mappedProgrammingLanguage);
                CreatedProgrammingLanguageEntityDto createdProgrammingLanguageEntityDto = _mapper.Map<CreatedProgrammingLanguageEntityDto>(createdProgrammingLanguage);

                return createdProgrammingLanguageEntityDto;
            }
        }
    }
}
