using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                if(ex is ValidationException)
                {
                    ValidationException validationException = ex as ValidationException;

                    ValidationProblemDetails validationProblemDetails = new(validationException.Errors.ToList());

                    await context.Response.WriteAsync(JsonSerializer.Serialize(validationProblemDetails));
                }
                else if (ex is BusinessException)
                {
                    ProblemDetails problemDetails = new();
                    problemDetails.Title = "Business Rule Violation";
                    problemDetails.Detail = ex.Message;
                    problemDetails.Type = "BusinessException";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                }
                else
                {
                    await context.Response.WriteAsync(ex.Message);
                }
            }
        }
    }
}
