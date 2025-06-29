using AtlanticProductDesing.API.Errors;
using AtlanticProductDesing.Application.Exceptions;
using Newtonsoft.Json;
using NLog;
using System.Net;


namespace AtlanticProductDesing.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                context.Response.ContentType = "Application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;


                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message));
                        break;

                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, validationJson));
                        break;

                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message));
                        break;

                    case ConflictException badRequestException:
                        statusCode = (int)HttpStatusCode.Conflict;
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message));
                        break;

                    case ForbiddenException forbiddenException:
                        statusCode = (int)HttpStatusCode.Forbidden;
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message));
                        break;

                    case UnauthorizedAccessException unauthorizedAccessException:
                        statusCode = (int)HttpStatusCode.Unauthorized;
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message));
                        break;


                    default:
                        break;

                }



                if (string.IsNullOrEmpty(result))
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace));


                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(result);

            }
        }
    }
}
