using AutoMapper;
using Devs.Application.Features.technologies.Dtos.TechnologyDtos;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.technologies.Commands.UpdateTechnology
{
    public partial class UpdateTechnologyEntityCommand : IRequest<UpdatedTechnologyEntityDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }      

        public class UpdateTechnologyEntityCommandHandler : IRequestHandler<UpdateTechnologyEntityCommand, UpdatedTechnologyEntityDto>
        {
            private readonly ITechnologyEntityRepository _technologyEntityRepository;
            private readonly IMapper _mapper;            

            public UpdateTechnologyEntityCommandHandler(ITechnologyEntityRepository technologyEntityRepository, IMapper mapper)
            {
                _technologyEntityRepository = technologyEntityRepository;
                _mapper = mapper;                
            }

            public async Task<UpdatedTechnologyEntityDto> Handle(UpdateTechnologyEntityCommand request, CancellationToken cancellationToken)
            {               
                TechnologyEntity mappedTechnologyEntity = _mapper.Map<TechnologyEntity>(request);
                
                TechnologyEntity updatedTechnologyEntity = await _technologyEntityRepository.UpdateAsync(mappedTechnologyEntity);
                UpdatedTechnologyEntityDto updatedTechnologyEntityDto = _mapper.Map<UpdatedTechnologyEntityDto>(updatedTechnologyEntity);

                return updatedTechnologyEntityDto;
            }
        }
    }
}
