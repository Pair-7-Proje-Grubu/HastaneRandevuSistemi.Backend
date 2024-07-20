using Application.Services.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator _mediator => HttpContext.RequestServices.GetService<IMediator>() ?? throw new InvalidOperationException("IMediator can not be resolved.");

        protected string getIpAddress()
        {
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        protected async Task<IActionResult> PagedQuery<TQuery, TResponse>(int page = 1, int pageSize = 10)
            where TQuery : PaginationParams, IRequest<PagedResponse<List<TResponse>>>, new()
        {
            var query = new TQuery { PageNumber = page, PageSize = pageSize };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}