using Application.Features.NoWorkHours.Commands.Create;
using Application.Features.NoWorkHours.Queries.GetById;
using Application.Features.NoWorkHours.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoWorkHourController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NoWorkHourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateNoWorkHourCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] CreateNoWorkHourCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] CreateNoWorkHourCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdQuery getByIdNoWorkHourQuery)
        {
            GetByIdNoWorkHourResponse result = await _mediator.Send(getByIdNoWorkHourQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListQuery getListQuery = new GetListQuery();
            List<GetListNoWorkHourResponse> result = await _mediator.Send(getListQuery);

            return Ok(result);
        }
    }
}
