using Application.Features.Users.Commands.Update.ChangePassword;
using Application.Features.Users.Commands.Update.ChangePhoneNumber;
using Application.Features.Users.Queries.GetPhoneNumber;
using Application.Features.Users.Queries.GetProfile;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("ChangePhoneNumber")]
        public async Task<IActionResult> ChangePhoneNumber([FromBody] ChangePhoneNumberCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetPhoneNumber/{email}")]
        public async Task<IActionResult> GetPhoneNumber([FromRoute] GetPhoneNumberQuery getPhoneNumberQuery)
        {
            var result = await _mediator.Send(getPhoneNumberQuery);
            return Ok(result);
        }

        [HttpGet("GetProfile")]
        public async Task<IActionResult> GetProfile([FromQuery] GetProfileQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}