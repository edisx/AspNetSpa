var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api", () => "hello mir");

app.MapFallbackToFile("/index.html");

app.Run();
