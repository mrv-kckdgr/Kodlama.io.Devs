using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Repositories
{
    public class ProgrammingLanguageEntityRepository : EfRepositoryBase<ProgrammingLanguageEntity, BaseDbContext>, IProgrammingLanguageEntityRepository
    {
        public ProgrammingLanguageEntityRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
