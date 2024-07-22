using Application.Features.Clinics.Commands.Create;
using Application.Features.Clinics.Commands.Delete;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Clinics.Queries.GetByIdClinic;
using Application.Features.Clinics.Queries.GetListClinic;
using Application.Features.Clinics.Commands.Update;
using Application.Features.Clinics.Dtos;
namespace WebAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : BaseController
    {

        [HttpGet("GetClinic")]
        public async Task<IActionResult> GetClinic()
        {
            GetClinicQuery getClinicQuery = new();
            GetClinicResponse result = await _mediator.Send(getClinicQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListClinicQuery getListClinicQuery = new();
            List<GetListClinicDto> result = await _mediator.Send(getListClinicQuery);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CreateClinicCommand command)
        {
            CreateClinicResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteClinicCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateClinicCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
