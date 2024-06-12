using Application.Features.OfficeLocations.Commands.Create;
using Application.Features.OfficeLocations.Commands.Delete;
using Application.Features.OfficeLocations.Commands.Update;
using Application.Features.OfficeLocations.Queries.GetById;
using Application.Features.OfficeLocations.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeLocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfficeLocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOfficeLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListOfficeLocationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdOfficeLocationQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteOfficeLocationCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOfficeLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
