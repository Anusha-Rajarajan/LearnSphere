using System.Net;
using System.Text.Json;

namespace LearnSphere.API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _log;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> log)
    {
        _next = next; _log = log;
    }

    public async Task Invoke(HttpContext ctx)
    {
        try { await _next(ctx); }
        catch (Exception ex)
        {
            _log.LogError(ex, "Unhandled error");
            ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ctx.Response.ContentType = "application/json";
            var payload = JsonSerializer.Serialize(new { error = "Server error", detail = ex.Message });
            await ctx.Response.WriteAsync(payload);
        }
    }
}
