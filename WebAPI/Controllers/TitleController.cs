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
    public class TitleController : BaseController
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateTitleCommand command)
        {
            CreateTitleResponse response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
