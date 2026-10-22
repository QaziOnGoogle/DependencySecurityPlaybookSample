using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Module1.Api.Tests;

public class Module1ApiEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public Module1ApiEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Root_ReturnsRunningStatus()
    {
        var response = await _client.GetAsync("/", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken));
        Assert.Equal("Module 1 API", body.RootElement.GetProperty("application").GetString());
        Assert.Equal("running", body.RootElement.GetProperty("status").GetString());
        Assert.Equal(".NET 10", body.RootElement.GetProperty("framework").GetString());
    }

    [Fact]
    public async Task Status_ReturnsHealthy()
    {
        var response = await _client.GetAsync("/api/module1/status", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken));
        Assert.Equal("healthy", body.RootElement.GetProperty("status").GetString());
        Assert.True(body.RootElement.TryGetProperty("utcTime", out _));
    }
}
