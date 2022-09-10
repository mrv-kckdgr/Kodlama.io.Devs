using Core.Application.Requests;
using Devs.Application.Features.programmingLanguages.Commands.CreateProgrammingLanguage;
using Devs.Application.Features.programmingLanguages.Commands.DeleteProgrammingLanguage;
using Devs.Application.Features.programmingLanguages.Commands.UpdateProgrammingLanguage;
using Devs.Application.Features.programmingLanguages.Dtos.ProgrammingLanguageDtos;
using Devs.Application.Features.programmingLanguages.Models;
using Devs.Application.Features.programmingLanguages.Queries.GeListProgrammingLanguageEntity;
using Devs.Application.Features.programmingLanguages.Queries.GetByIdProgrammingLanguageEntity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageEntitiesController : BaseController
    {       

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageEntityCommand createProgrammingLanguageEntityCommand)
        {
            CreatedProgrammingLanguageEntityDto result = await Mediator.Send(createProgrammingLanguageEntityCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageEntityCommand updateProgrammingLanguageEntityCommand)
        {
            UpdatedProgrammingLanguageEntityDto result = await Mediator.Send(updateProgrammingLanguageEntityCommand);
            return Created("", result);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageEntityCommand deleteProgrammingLanguageEntityCommand)
        {
            DeletedProgrammingLanguageEntityDto result = await Mediator.Send(deleteProgrammingLanguageEntityCommand);
            return Created("", result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageEntityQuery getListProgrammingLanguageEntityQuery = new() { PageRequest = pageRequest };
            ProgramminLanguageEntityListModel result = await Mediator.Send(getListProgrammingLanguageEntityQuery);
            return Ok(result);
        }

        [HttpGet("getById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageEntityQuery getByIdProgrammingLanguageEntityQuery)
        {
            ProgrammingLanguageEntityGetByIdDto programmingLanguageEntityGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageEntityQuery);
            return Ok(programmingLanguageEntityGetByIdDto);
        }

    }
}
