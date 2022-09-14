using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.technologies.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.technologies.Queries.GetListTechnology
{
    public class GetListTechnologyEntityQuery : IRequest<TechnologyEntityListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyEntityQuery, TechnologyEntityListModel>
        {
            private readonly ITechnologyEntityRepository _technologyEntityRepository;
            private readonly IMapper _mapper;

            public GetListTechnologyQueryHandler(ITechnologyEntityRepository technologyEntityRepository, IMapper mapper)
            {
                _technologyEntityRepository = technologyEntityRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyEntityListModel> Handle(GetListTechnologyEntityQuery request, CancellationToken cancellationToken)
            {
                IPaginate<TechnologyEntity> technologies = await _technologyEntityRepository.GetListAsync(include:
                                                                x => x.Include(y => y.ProgrammingLanguage),
                                                                index: request.PageRequest.Page,
                                                                size: request.PageRequest.PageSize
                                                                );
                TechnologyEntityListModel mappedTechnologies = _mapper.Map<TechnologyEntityListModel>(technologies);
                return mappedTechnologies;
            }
        }
    }
}
