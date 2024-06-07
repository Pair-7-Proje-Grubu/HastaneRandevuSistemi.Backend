using Application.Features.Appointments.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AppointmentController : BaseController
    {


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentCommand command)
        {
            CreateAppointmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }


        //[HttpPost("GetListAvailableAppointments")] //GetListAvailableAppointments
        //public async Task<IActionResult> GetListAvailable([FromBody] GetListAvailableAppointmentCommand command)
        //{
        //    CreateAppointmentResponse response = await _mediator.Send(command);
        //    return Ok(response);
        //}
    }
}
