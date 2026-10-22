var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    application = "Module 1 API",
    status = "running",
    framework = ".NET 10"
}));

app.MapGet("/api/module1/status", () => Results.Ok(new
{
    application = "Module 1 API",
    status = "healthy",
    utcTime = DateTimeOffset.UtcNow
}));

app.Run();
