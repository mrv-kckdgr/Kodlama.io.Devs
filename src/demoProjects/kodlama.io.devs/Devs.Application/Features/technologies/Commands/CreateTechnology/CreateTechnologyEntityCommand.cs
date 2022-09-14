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

namespace Devs.Application.Features.technologies.Commands.CreateTechnology
{
    public class CreateTechnologyEntityCommand : IRequest<CreatedTechnologyEntityDto>
    {
        public string Name { get; set; }

        public class CreateTechnologyEntityCommandHandler : IRequestHandler<CreateTechnologyEntityCommand, CreatedTechnologyEntityDto>
        {
            private readonly ITechnologyEntityRepository _technologyEntityRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyEntityBusinessRules _technologyEntityBusinessRules;

            public async Task<CreatedTechnologyEntityDto> Handle(CreateTechnologyEntityCommand request, CancellationToken cancellationToken)
            {
                await _technologyEntityBusinessRules.TechnologyEntityNameCanNotBeDuplicatedWhenInserted(request.Name);

                TechnologyEntity mappedTechnologyEntity = _mapper.Map<TechnologyEntity>(request);
                TechnologyEntity createdTechnologyEntity = await _technologyEntityRepository.AddAsync(mappedTechnologyEntity);
                CreatedTechnologyEntityDto createdTechnologyEntityDto = _mapper.Map<CreatedTechnologyEntityDto>(createdTechnologyEntity);

                return createdTechnologyEntityDto;
            }
        }
    }
}
