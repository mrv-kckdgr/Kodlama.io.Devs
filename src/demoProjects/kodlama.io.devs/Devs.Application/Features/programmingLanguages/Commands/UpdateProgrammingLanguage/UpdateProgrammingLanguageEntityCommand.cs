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

namespace Devs.Application.Features.programmingLanguages.Commands.UpdateProgrammingLanguage
{    
    public partial class UpdateProgrammingLanguageEntityCommand : IRequest<UpdatedProgrammingLanguageEntityDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguageEntityCommandHandler : IRequestHandler<UpdateProgrammingLanguageEntityCommand, UpdatedProgrammingLanguageEntityDto>
        {
            private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageEntityBusinessRules _programmingLanguageEntityBusinessRules;

            public UpdateProgrammingLanguageEntityCommandHandler(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository, IMapper mapper, ProgrammingLanguageEntityBusinessRules programmingLanguageEntityBusinessRules)
            {
                _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
                _mapper = mapper;
                _programmingLanguageEntityBusinessRules = programmingLanguageEntityBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageEntityDto> Handle(UpdateProgrammingLanguageEntityCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageEntityBusinessRules.ProgrammingLanguageEntityNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguageEntity mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguageEntity>(request);
                ProgrammingLanguageEntity updatedProgrammingLanguage = await _programmingLanguageEntityRepository.UpdateAsync(mappedProgrammingLanguage);
                UpdatedProgrammingLanguageEntityDto updatedProgrammingLanguageEntityDto = _mapper.Map<UpdatedProgrammingLanguageEntityDto>(updatedProgrammingLanguage);

                return updatedProgrammingLanguageEntityDto;
            }
        }
    }
}
