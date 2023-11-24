using HomeMgmtAPI.BusinessLayer.Exceptions;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;

namespace HomeMgmtAPI.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                if (ex is BusinessRuleException)
                {
                    var businessRuleException = ex as BusinessRuleException;

                    context.Response.ContentType = "application/problem+json";
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    var response = new CustomResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Description = "One or more validation errors occurred.",
                        Errors = businessRuleException.Errors
                    };

                    await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
                }
                else if (ex is ResourceNotFoundException)
                {
                    var resourceNotFounException = ex as ResourceNotFoundException;

                    context.Response.ContentType = "application/problem+json";
                    context.Response.StatusCode = StatusCodes.Status404NotFound;

                    var response = new CustomResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Description = resourceNotFounException.ErrorMessage
                    };

                    await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
