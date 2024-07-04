using Application.Features.Auth.Login;
using Application.Features.Auth.Register;
using Application.Features.Users.Commands.Update;
using Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IPatientRepository _patientRepository;

        public UserController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("change-phone-number")]
        public async Task<IActionResult> ChangePhoneNumber([FromBody] ChangePhoneNumberCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("get-phone-number/{email}")]
        public async Task<IActionResult> GetPhoneNumber(string email)
        {
            var patient = await _patientRepository.GetAsync(p => p.Email == email);
            if (patient == null)
            {
                return NotFound("Hasta bulunamadı");
            }
            return Ok(patient.Phone);
        }
    }
}