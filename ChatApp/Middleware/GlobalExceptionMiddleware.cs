using ChatApp.Api.ApiResponse;
using FluentValidation;
using System.Text.Json;

namespace ChatApp.Api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public GlobalExceptionMiddleware(RequestDelegate next,ILogger<GlobalExceptionMiddleware> logger,IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An unhandled exception occurred");

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context,Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = new ApiErrorResponse();

            switch (ex)
            {
                case ValidationException validationException:

                    context.Response.StatusCode =StatusCodes.Status400BadRequest;

                    response.Message = "Validation Failed";

                    response.Errors = validationException.Errors
                    .Select(x => $"{x.PropertyName}: {x.ErrorMessage}")
                    .ToList();

                    break;

                case UnauthorizedAccessException:

                    context.Response.StatusCode =StatusCodes.Status401Unauthorized;

                    response.Message = "Unauthorized";

                    break;

                case KeyNotFoundException:

                    context.Response.StatusCode =StatusCodes.Status404NotFound;

                    response.Message = ex.Message;

                    break;

                default:

                    context.Response.StatusCode =StatusCodes.Status500InternalServerError;

                    response.Message = "Internal Server Error";

                    break;
            }

            // يظهر فقط في development
            if (_environment.IsDevelopment())
            {
                response.Details = ex.Message;
            }

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}
