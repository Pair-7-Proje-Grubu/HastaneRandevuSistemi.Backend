using Application.Features.Clinics.Commands.Create;
using Application.Features.Clinics.Commands.Delete;
using Application.Repositories;
using Core.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("GetClinic")]
        public async Task<IActionResult> GetClinic([FromRoute] GetClinicQuery getClinicQuery)
        {
            GetClinicResponse result = await _mediator.Send(getClinicQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListClinicQuery getListClinicQuery = new GetListClinicQuery();
            List<GetListClinicDto> result = await _mediator.Send(getListClinicQuery);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CreateClinicCommand command)
        {
            CreateClinicResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteClinicCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateClinicCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
