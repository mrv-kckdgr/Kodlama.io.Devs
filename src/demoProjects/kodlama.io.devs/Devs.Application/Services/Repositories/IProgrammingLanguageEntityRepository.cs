﻿using Core.Persistence.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Services.Repositories
{
    public interface IProgrammingLanguageEntityRepository:IAsyncRepository<ProgrammingLanguageEntity>, IRepository<ProgrammingLanguageEntity>
    {
    }
}
