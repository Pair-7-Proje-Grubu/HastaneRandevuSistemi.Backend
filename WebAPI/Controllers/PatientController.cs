using Application.Features.Patients.Commands.Update;
using Application.Features.Patients.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseController
    {
        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetListPatient([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return await PagedQuery<GetListPatientQuery, GetListPatientResponse>(page, pageSize);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdatePatientCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }

}
