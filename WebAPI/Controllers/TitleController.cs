using Application.Features.Titles.Queries.GetByIdTitle;
using Application.Features.Titles.Commands.Delete;
using Application.Features.Titles.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Titles.Queries.GetListTitle;
using Application.Features.Titles.Commands.Update;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : BaseController
    {

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTitleQuery getByIdTitleQuery)
        {
            GetByIdTitleResponse result = await _mediator.Send(getByIdTitleQuery);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            GetListTitleQuery query = new();
            List<GetListTitleResponse> result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CreateTitleCommand command)
        {
            CreateTitleResponse response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteTitleCommand command = new() { Id = id};
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateTitleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


    }
}
