using OperationAPI.API.Models;
using OperationAPI.Application.Exceptions;
using System.Net;

namespace OperationAPI.API.MiddelWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //if (context.Request.Method == "OPTIONS")
                //{
                //    context.Response.StatusCode = StatusCodes.Status200OK;

                //    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                //    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                //    context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

                //    await context.Response.CompleteAsync();
                //    return;
                //}
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomProblemDetails problem = new();

            switch (ex)
            {
                case BadRequestException _badReequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails
                    {
                        Title = _badReequestException.Message,
                        Status = (int)statusCode,
                        Detail = _badReequestException.InnerException?.Message,
                        Type = nameof(BadRequestException),
                        Errors = _badReequestException.ValidationErrors
                    };
                    break;
                case NotFoundException _notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CustomProblemDetails
                    {
                        Title = _notFoundException.Message,
                        Status = (int)statusCode,
                        Detail = _notFoundException.InnerException?.Message,
                        Type = nameof(NotFoundException)
                    };
                    break;
                default:
                    problem = new CustomProblemDetails
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Detail = ex.StackTrace,
                        Type = nameof(HttpStatusCode.InternalServerError)
                    };
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var ResponseException = new ResponseDTO<CustomProblemDetails>()
            {
                status = "Error",
                message = ex.Message,
                data = problem,
            };

            await context.Response.WriteAsJsonAsync(ResponseException);
        }
    }

}
