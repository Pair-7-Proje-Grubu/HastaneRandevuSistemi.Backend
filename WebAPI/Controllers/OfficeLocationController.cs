using Application.Features.OfficeLocations.Commands.Create;
using Application.Features.OfficeLocations.Commands.Delete;
using Application.Features.OfficeLocations.Commands.Update;
using Application.Features.OfficeLocations.Queries.GetById;
using Application.Features.OfficeLocations.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeLocationController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOfficeLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteOfficeLocationCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateOfficeLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListOfficeLocationQuery query = new();
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
    }
}
