using Application.Features.Allergies.Commands.Create;
using Application.Features.Allergies.Commands.Delete;
using Application.Features.Allergies.Commands.Update;
using Application.Features.Allergies.Queries.GetByIdAllergy;
using Application.Features.Allergies.Queries.GetListAllergy;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : BaseController
    {

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAllergyQuery getByIdAllergyQuery)
        {
            GetByIdAllergyResponse result = await _mediator.Send(getByIdAllergyQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListAllergyQuery getListAllergyQuery = new();
            GetListAllergyResponse result = await _mediator.Send(getListAllergyQuery);
            return Ok(result);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateAllergyCommand command)
        {
            CreateAllergyResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteAllergyCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateAllergyCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
