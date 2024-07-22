using Application.Features.FAQs.Command.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateFAQCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
