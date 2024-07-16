using Application.Features.Doctors.Commands.CreateDoctor;
using Application.Features.Doctors.Commands.UpdateDoctor;
using Application.Features.Doctors.Queries.GetByClinicIdDoctor;
using Application.Features.Doctors.Queries.GetByIdDoctor;
using Application.Features.Doctors.Queries.GetListDoctor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DoctorController : BaseController
    {

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] CreateDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdDoctorQuery getByIdDoctorQuery)
        {
            GetByIdDoctorResponse result = await _mediator.Send(getByIdDoctorQuery);
            return Ok(result);
        }

        [HttpGet("GetByClinicId/{ClinicId}")]
        public async Task<IActionResult> GetByClinicId([FromRoute] GetByClinicIdDoctorQuery getByClinicIdDoctorQuery)
        {
            List<GetByClinicIdDoctorResponse> result = await _mediator.Send(getByClinicIdDoctorQuery);
            return Ok(result);
        }

        [HttpGet("GetListDoctor")]
        public async Task<IActionResult> GetList([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return await PagedQuery<GetListDoctorQuery, GetListDoctorResponse>(page, pageSize);
        }
    }
}
