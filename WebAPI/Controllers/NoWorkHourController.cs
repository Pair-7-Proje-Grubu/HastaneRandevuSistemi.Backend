using Application.Features.NoWorkHours.Commands.Create;
using Application.Features.NoWorkHours.Commands.Delete;
using Application.Features.NoWorkHours.Commands.Update;
using Application.Features.NoWorkHours.Queries.GetById;
using Application.Features.NoWorkHours.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoWorkHourController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateNoWorkHourCommand command)
        {
            if (command is null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteNoWorkHourCommand command = new () { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateNoWorkHourCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdQuery getByIdNoWorkHourQuery)
        {
            GetByIdNoWorkHourResponse result = await _mediator.Send(getByIdNoWorkHourQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] GetListNoWorkHourQuery query)
        {
            List<GetListNoWorkHourResponse> result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
