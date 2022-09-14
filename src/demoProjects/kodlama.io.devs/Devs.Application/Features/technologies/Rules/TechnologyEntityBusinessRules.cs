using Core.Persistence.Paging;
using Devs.Application.Features.technologies.Commands.CreateTechnology;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.technologies.Rules
{
    public class TechnologyEntityBusinessRules
    {
        private readonly ITechnologyEntityRepository _technologyEntityRepository;

        public TechnologyEntityBusinessRules(ITechnologyEntityRepository technologyEntityRepository)
        {
            _technologyEntityRepository = technologyEntityRepository;
        }

        public async Task TechnologyEntityNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<TechnologyEntity> result = await _technologyEntityRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any()) throw new Exception("TechnologyEntity name exists!");
        }

        public void TechnologyEntityShouldExistsWhenRequested(TechnologyEntity technologyEntity)
        {
            if(technologyEntity==null) throw new Exception("Requested does not exist!");
        }
    }
}
