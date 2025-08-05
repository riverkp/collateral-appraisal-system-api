using System.Text.Json;
using Integration.Fixtures;
using Integration.Helpers;
using Request.Contracts.Requests.Features.GetRequestById;
using Request.Requests.Features.CreateRequest;

namespace Integration.Request.Integration.Tests;

public class GetRequestByIdTests(IntegrationTestFixture fixture) : IntegrationTestBase(fixture)
{
    [Fact]
    public async Task GetRequestById_ValidRequest_ReturnsSuccess()
    {
        // Create request first
        var content = await JsonHelper.JsonToStringContent("Request.Integration.Tests", "CreateRequest_ValidRequest.json");
        var response = await _client.PostAsync("/requests", content, TestContext.Current.CancellationToken);

        var responseContent = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var result = JsonSerializer.Deserialize<CreateRequestResult>(responseContent, JsonHelper.Options);
        Assert.NotNull(result);

        // Get the request by Id
        var getResponse = await _client.GetAsync($"/requests/{result.Id}", TestContext.Current.CancellationToken);
        
        var getStatusCodeException = Record.Exception(getResponse.EnsureSuccessStatusCode);
        Assert.Null(getStatusCodeException);

        var getResponseContent = await getResponse.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var getResult = JsonSerializer.Deserialize<GetRequestByIdResult>(getResponseContent, JsonHelper.Options);
        Assert.NotNull(getResult);
        Assert.Equivalent(getResult.Id, result.Id);
    }
}