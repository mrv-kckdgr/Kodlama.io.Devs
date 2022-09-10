using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.programmingLanguages.Rules
{
    public class ProgrammingLanguageEntityBusinessRules
    {
        private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;

        public ProgrammingLanguageEntityBusinessRules(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository)
        {
            _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
        }

        public async Task ProgrammingLanguageEntityNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguageEntity> result = await _programmingLanguageEntityRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("ProgrammingLanguageEntity name exists.");
        }

        public void ProgrammingLanguageEntityShouldExistsWhenRequested(ProgrammingLanguageEntity programmingLanguageEntity)
        {
            if (programmingLanguageEntity == null) throw new BusinessException("Requested dost not exist!");
        }
    }
}
