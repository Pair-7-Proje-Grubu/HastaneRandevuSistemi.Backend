using Application.Features.Appointments.Commands.Create;
using Application.Features.Appointments.Queries.GetListAppointment;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AppointmentController : BaseController
    {


        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentCommand command)
        {
            CreateAppointmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpPost("List")]
        public async Task<IActionResult> GetList([FromBody] GetListAppointmentQuery command)
        {
            GetListAppointmentResponse response = await _mediator.Send(command);
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
