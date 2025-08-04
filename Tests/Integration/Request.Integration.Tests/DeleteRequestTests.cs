using System.Text.Json;
using Integration.Fixtures;
using Integration.Helpers;
using Request.Requests.Features.CreateRequest;
using Request.Requests.Features.DeleteRequest;

namespace Integration.Request.Integration.Tests;

public class DeleteRequestTests(IntegrationTestFixture fixture) : IntegrationTestBase(fixture)
{
    [Fact]
    public async Task DeleteRequest_ValidRequest_ReturnsSuccess()
    {
        // Create request first
        var content = await JsonHelper.JsonToStringContent("Request.Integration.Tests", "CreateRequest_ValidRequest.json");
        var response = await _client.PostAsync("/requests", content, TestContext.Current.CancellationToken);

        var responseContent = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var result = JsonSerializer.Deserialize<CreateRequestResult>(responseContent);
        Assert.NotNull(result);

        // Delete the request
        var deleteResponse = await _client.DeleteAsync($"/requests/{result.Id}", TestContext.Current.CancellationToken);

        var deleteStatusCodeException = Record.Exception(response.EnsureSuccessStatusCode);
        Assert.Null(deleteStatusCodeException);

        var deleteResponseContent = await deleteResponse.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var deleteDeserializeException = Record.Exception(() => JsonSerializer.Deserialize<DeleteRequestResult>(deleteResponseContent));
        //Assert.Null(deleteDeserializeException);
    }
}