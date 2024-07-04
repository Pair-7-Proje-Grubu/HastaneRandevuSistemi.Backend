using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Feedbacks.Queries.GetByIdFeedback;
using Application.Features.Feedbacks.Queries.GetListFeedback;
using Application.Features.Feedbacks.Commands.Create;
using MediatR;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdFeedbackQuery getByIdFeedbackQuery)
        {
            GetByIdFeedbackResponse result = await _mediator.Send(getByIdFeedbackQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListFeedbackQuery getListFeedbackQuery = new GetListFeedbackQuery();
            List<GetListFeedbackResponse> result = await _mediator.Send(getListFeedbackQuery);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateFeedbackCommand command)
        {
            CreateFeedbackResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
