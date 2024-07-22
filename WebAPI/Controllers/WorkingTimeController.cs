using Application.Features.WorkingTimes.Commands.Create;
using Application.Features.WorkingTimes.Commands.Delete;
using Application.Features.WorkingTimes.Commands.Update;
using Application.Features.WorkingTimes.Queries.GetById;
using Application.Features.WorkingTimes.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingTimeController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            GetByIdWorkingTimeQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]GetListWorkingTimeQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateWorkingTimeCommand command)
        {
            CreateWorkingTimeResponse result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteWorkingTimeCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateWorkingTimeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
