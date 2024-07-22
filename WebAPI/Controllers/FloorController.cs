using Application.Features.Blocks.Queries.GetList;
using Application.Features.Floors.Commands.Create;
using Application.Features.Floors.Commands.Delete;
using Application.Features.Floors.Commands.Update;
using Application.Features.Floors.Queries.GetById;
using Application.Features.Floors.Queries.GetList;
using Application.Features.Titles.Queries.GetListTitle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateFloorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteFloorCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateFloorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListFloorQuery query = new GetListFloorQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdFloorQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }  
    }
}
