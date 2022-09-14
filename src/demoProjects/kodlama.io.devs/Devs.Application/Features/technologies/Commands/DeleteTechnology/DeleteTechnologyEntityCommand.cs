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

namespace Devs.Application.Features.technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyEntityCommand : IRequest<DeletedTechnologyEntityDto>
    {
        public int Id { get; set; }
        public class DeleteTechnologyEntityCommandHandler : IRequestHandler<DeleteTechnologyEntityCommand, DeletedTechnologyEntityDto>
        {
            private readonly ITechnologyEntityRepository _technologyEntityRepository;
            private readonly IMapper _mapper;

            public DeleteTechnologyEntityCommandHandler(ITechnologyEntityRepository technologyEntityRepository, IMapper mapper)
            {
                _technologyEntityRepository = technologyEntityRepository;
                _mapper = mapper;
            }

            public async Task<DeletedTechnologyEntityDto> Handle(DeleteTechnologyEntityCommand request, CancellationToken cancellationToken)
            {
                TechnologyEntity mappedTechnologyEntity = _mapper.Map<TechnologyEntity>(request);
                TechnologyEntity deletedTechnologyEntity = await _technologyEntityRepository.DeleteAsync(mappedTechnologyEntity);
                DeletedTechnologyEntityDto deletedTechnologyEntityDto = _mapper.Map<DeletedTechnologyEntityDto>(deletedTechnologyEntity);

                return deletedTechnologyEntityDto;
            }
        }
    }
}
