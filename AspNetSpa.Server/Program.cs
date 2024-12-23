var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole(options =>
{
    options.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ";
    options.SingleLine = true;
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api", () => "hello mir");

app.MapGet("/api/visitor", (ILogger<Program> logger, HttpContext context) =>
{
    var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
    logger.LogInformation($"Visitor from IP: {ip}");

    return Results.Ok(new { ip });
});

app.MapFallbackToFile("/index.html");

app.Run();
