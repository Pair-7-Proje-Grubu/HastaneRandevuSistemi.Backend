using Application.Features.Clinics.Queries.GetListClinic;
using Application.Features.Floors.Queries.GetList;
using Application.Features.OfficeLocations.Queries.GetList;
using Application.Features.Reports.Commands.Create;
using Application.Features.Rooms.Commands.Create;
using Application.Features.Rooms.Commands.Delete;
using Application.Features.Rooms.Commands.Update;
using Application.Features.Rooms.Queries.GetById;
using Application.Features.Rooms.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateRoomCommand command)
        {
            var result =await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteRoomCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateRoomCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListRoomQuery query = new GetListRoomQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdRoomQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
