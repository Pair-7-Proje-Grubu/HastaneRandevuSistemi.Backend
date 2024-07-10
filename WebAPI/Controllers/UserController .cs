using Application.Features.Auth.Login;
using Application.Features.Auth.Register;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetProfile;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Extensions;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IPatientRepository patientRepository, IHttpContextAccessor httpContextAccessor)
        {
            _patientRepository = patientRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("ChangePhoneNumber")]
        public async Task<IActionResult> ChangePhoneNumber([FromBody] ChangePhoneNumberCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetPhoneNumber/{email}")]
        public async Task<IActionResult> GetPhoneNumber(string email)
        {
            var patient = await _patientRepository.GetAsync(p => p.Email == email);
            if (patient == null)
            {
                return NotFound("Hasta bulunamadı");
            }

            return Ok(patient.Phone);
        }

        [HttpGet("GetProfile")]
        public async Task<IActionResult> GetProfile()
        {
            int userId = _httpContextAccessor.HttpContext.User.GetUserId();

            Patient? patient = await _patientRepository.GetAsync(x => x.Id == userId);
            if (patient is null) throw new BusinessException("Bu ID'de bir hasta bulunamadı!");
            GetProfileResponse result = new GetProfileResponse()
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,
            };
            return Ok(result);
        }
    }
}