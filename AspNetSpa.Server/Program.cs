var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/api", () => "hello mir");

app.Run();
