using Application.Features.Blocks.Commands.Create;
using Application.Features.Blocks.Commands.Delete;
using Application.Features.Blocks.Commands.Update;
using Application.Features.Blocks.Queries.GetById;
using Application.Features.Blocks.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlockCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListBlockQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdBlockQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteBlockCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok(); // Refactor
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlockCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
