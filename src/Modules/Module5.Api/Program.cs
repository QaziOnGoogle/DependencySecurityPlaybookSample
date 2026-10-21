var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    application = "Module 5 API",
    status = "running",
    framework = ".NET 8"
}));

app.MapGet("/api/module5/status", () => Results.Ok(new
{
    application = "Module 5 API",
    status = "healthy",
    utcTime = DateTimeOffset.UtcNow
}));

app.Run();
