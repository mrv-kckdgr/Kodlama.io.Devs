﻿using Devs.Application.Services.Repositories;
using Devs.Persistence.Contexts;
using Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("KodlamaIODevsConnectionString")));

            services.AddScoped<IProgrammingLanguageEntityRepository, ProgrammingLanguageEntityRepository>();
            services.AddScoped<ITechnologyEntityRepository, TechnologyEntityRepository>();

            return services;
        }
    }
}
