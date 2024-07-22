using Application.Features.Floors.Commands.Create;
using Application.Features.Floors.Queries.GetList;
using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Queires.GetListOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand command)
        {
            CreateOperationClaimResponse result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromHeader]GetListOperationClaimQuery query)
        {
            List<GetListOperationClaimResponse> result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
