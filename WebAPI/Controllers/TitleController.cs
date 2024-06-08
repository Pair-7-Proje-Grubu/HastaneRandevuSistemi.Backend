using Application.Features.Titles.Queries.GetByIdTitle;
using Application.Features.Titles.Commands.Delete;
using Application.Features.Titles.Commands.Create;
using Application.Repositories;
using Core.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Http;
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
            GetListTitleQuery getListTitleQuery = new GetListTitleQuery();
            GetListTitleResponse result = await _mediator.Send(getListTitleQuery);
            return Ok(result);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CreateTitleCommand command)
        {
            CreateTitleResponse response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTitleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateTitleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


    }
}
