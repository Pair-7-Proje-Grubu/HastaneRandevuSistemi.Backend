using Application.Features.Doctors.Commands.CreateDoctor;
using Application.Features.Doctors.Queries.GetByIdDoctor;
using Application.Features.Doctors.Queries.GetListDoctor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DoctorController : ControllerBase
    {

        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
        public async Task<IActionResult> Update([FromBody] CreateDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdDoctorQuery getByIdDoctorQuery)
        {
            GetByIdDoctorResponse result = await _mediator.Send(getByIdDoctorQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListDoctorQuery getListDoctorQuery = new GetListDoctorQuery();
            GetListDoctorResponse result = await _mediator.Send(getListDoctorQuery);

            return Ok(result);
        }
    }
}
