using AutoMapper;
using Devs.Application.Features.technologies.Dtos.TechnologyDtos;
using Devs.Application.Features.technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyEntityQuery : IRequest<TechnologyEntityGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdTechnologyEntityQueryHandler : IRequestHandler<GetByIdTechnologyEntityQuery, TechnologyEntityGetByIdDto>
        {
            private readonly ITechnologyEntityRepository _technologyEntityRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyEntityBusinessRules _technologyEntityBusinessRules;

            public GetByIdTechnologyEntityQueryHandler(ITechnologyEntityRepository technologyEntityRepository, IMapper mapper, TechnologyEntityBusinessRules technologyEntityBusinessRules)
            {
                _technologyEntityRepository = technologyEntityRepository;
                _mapper = mapper;
                _technologyEntityBusinessRules = technologyEntityBusinessRules;
            }

            public async Task<TechnologyEntityGetByIdDto> Handle(GetByIdTechnologyEntityQuery request, CancellationToken cancellationToken)
            {
                TechnologyEntity? technologyEntity = await _technologyEntityRepository.GetAsync(x => x.Id == request.Id);

                _technologyEntityBusinessRules.TechnologyEntityShouldExistsWhenRequested(technologyEntity);

                TechnologyEntityGetByIdDto technologyEntityGetByIdDto = _mapper.Map<TechnologyEntityGetByIdDto>(technologyEntity);

                return technologyEntityGetByIdDto;
            }
        }
    }
}
