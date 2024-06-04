using Application.Features.Allergies.Commands.Create;
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
    public class AllergyController : BaseController
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAllergyCommand command)
        {
            CreateAllergyResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
