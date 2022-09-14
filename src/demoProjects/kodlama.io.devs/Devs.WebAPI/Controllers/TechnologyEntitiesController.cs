using Core.Application.Requests;
using Devs.Application.Features.technologies.Commands.CreateTechnology;
using Devs.Application.Features.technologies.Commands.DeleteTechnology;
using Devs.Application.Features.technologies.Commands.UpdateTechnology;
using Devs.Application.Features.technologies.Dtos.TechnologyDtos;
using Devs.Application.Features.technologies.Models;
using Devs.Application.Features.technologies.Queries.GetByIdTechnology;
using Devs.Application.Features.technologies.Queries.GetListTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyEntitiesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyEntityCommand createTechnologyEntityCommand)
        {
            CreatedTechnologyEntityDto createdTechnologyEntityDto = await Mediator.Send(createTechnologyEntityCommand);
            return Created("", createdTechnologyEntityDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyEntityCommand updateTechnologyEntityCommand)
        {
            UpdatedTechnologyEntityDto updatedTechnologyEntityDto = await Mediator.Send(updateTechnologyEntityCommand);
            return Ok(updatedTechnologyEntityDto);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyEntityCommand deleteTechnologyEntityCommand)
        {
            DeletedTechnologyEntityDto deletedTechnologyEntityDto = await Mediator.Send(deleteTechnologyEntityCommand);
            return Ok(deletedTechnologyEntityDto);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyEntityQuery getListTechnologyEntityQuery = new() { PageRequest=pageRequest };
            TechnologyEntityListModel result = await Mediator.Send(getListTechnologyEntityQuery);
            return Ok(result);
        }

        [HttpGet("getById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyEntityQuery getByIdTechnologyEntityQuery)
        {
            TechnologyEntityGetByIdDto technologyEntityGetByIdDto = await Mediator.Send(getByIdTechnologyEntityQuery);
            return Ok(technologyEntityGetByIdDto);
        }
    }
}
