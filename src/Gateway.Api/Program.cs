var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    application = "Gateway API",
    status = "running",
    framework = ".NET 8"
}));

app.MapGet("/api/gateway/status", () => Results.Ok(new
{
    application = "Gateway API",
    status = "healthy",
    utcTime = DateTimeOffset.UtcNow
}));

app.Run();
