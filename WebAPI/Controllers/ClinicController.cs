using Application.Features.Clinics.Commands.Create;
using Application.Features.Titles.Commands.Create;
using Application.Repositories;
using Core.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : BaseController
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateClinicCommand command)
        {
            CreateClinicResponse response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
