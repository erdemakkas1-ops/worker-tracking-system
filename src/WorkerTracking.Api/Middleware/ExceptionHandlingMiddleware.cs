using System.Net;
using System.Text.Json;
using FluentValidation;
using WorkerTracking.Application.Common.Models;

namespace WorkerTracking.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, errors) = exception switch
        {
            ValidationException validationException => (
                HttpStatusCode.BadRequest,
                validationException.Errors.Select(e => e.ErrorMessage).ToArray()),
            UnauthorizedAccessException => (
                HttpStatusCode.Unauthorized,
                new[] { exception.Message }),
            KeyNotFoundException => (
                HttpStatusCode.NotFound,
                new[] { exception.Message }),
            _ => (
                HttpStatusCode.InternalServerError,
                new[] { "An unexpected error occurred." })
        };

        if (statusCode == HttpStatusCode.InternalServerError)
        {
            _logger.LogError(exception, "Unhandled exception occurred.");
        }
        else
        {
            _logger.LogWarning(exception, "Request failed with {StatusCode}", statusCode);
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = ApiResponse<object>.Fail(errors);
        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(json);
    }
}
