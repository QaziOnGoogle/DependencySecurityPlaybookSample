using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Gateway.Api.Tests;

public class GatewayApiEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public GatewayApiEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Root_ReturnsRunningStatus()
    {
        var response = await _client.GetAsync("/", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken));
        Assert.Equal("Gateway API", body.RootElement.GetProperty("application").GetString());
        Assert.Equal("running", body.RootElement.GetProperty("status").GetString());
        Assert.Equal(".NET 10", body.RootElement.GetProperty("framework").GetString());
    }

    [Fact]
    public async Task Status_ReturnsHealthy()
    {
        var response = await _client.GetAsync("/api/gateway/status", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken));
        Assert.Equal("healthy", body.RootElement.GetProperty("status").GetString());
        Assert.True(body.RootElement.TryGetProperty("utcTime", out _));
    }
}
