using System.Text.Json;
using Integration.Fixtures;
using Integration.Helpers;
using Request.Requests.Features.CreateRequest;

namespace Integration.Request.Integration.Tests;

public class CreateRequestTests(IntegrationTestFixture fixture) : IntegrationTestBase(fixture)
{
    [Fact]
    public async Task CreateRequest_ValidRequest_ReturnsSuccess()
    {
        var content = await JsonHelper.JsonToStringContent("Request.Integration.Tests", "CreateRequest_ValidRequest.json");
        var response = await _client.PostAsync("/requests", content, TestContext.Current.CancellationToken);

        var statusCodeException = Record.Exception(response.EnsureSuccessStatusCode);
        Assert.Null(statusCodeException);

        var responseBody = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var deserializeException = Record.Exception(() => JsonSerializer.Deserialize<CreateRequestResult>(responseBody));
        Assert.Null(deserializeException);
    }
}