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

namespace Devs.Application.Features.programmingLanguages.Commands.DeleteProgrammingLanguage
{
    public partial class DeleteProgrammingLanguageEntityCommand : IRequest<DeletedProgrammingLanguageEntityDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageEntityCommandHandler : IRequestHandler<DeleteProgrammingLanguageEntityCommand, DeletedProgrammingLanguageEntityDto>
        {
            private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageEntityBusinessRules _programmingLanguageEntityBusinessRules;

            public DeleteProgrammingLanguageEntityCommandHandler(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository, IMapper mapper, ProgrammingLanguageEntityBusinessRules programmingLanguageEntityBusinessRules)
            {
                _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
                _mapper = mapper;
                _programmingLanguageEntityBusinessRules = programmingLanguageEntityBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageEntityDto> Handle(DeleteProgrammingLanguageEntityCommand request, CancellationToken cancellationToken)
            {                

                ProgrammingLanguageEntity mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguageEntity>(request);
                ProgrammingLanguageEntity deletedProgrammingLanguage = await _programmingLanguageEntityRepository.DeleteAsync(mappedProgrammingLanguage);
                DeletedProgrammingLanguageEntityDto deletedProgrammingLanguageEntityDto = _mapper.Map<DeletedProgrammingLanguageEntityDto>(deletedProgrammingLanguage);

                return deletedProgrammingLanguageEntityDto;
            }
        }
    }
}
