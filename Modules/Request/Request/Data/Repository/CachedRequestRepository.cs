using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Request.Data.JsonConverters;

namespace Request.Data.Repository;

public class CachedRequestRepository(IRequestRepository repository, IDistributedCache cache) : IRequestRepository
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters =
        {
            new RequestConverter(),
            //new RequestCustomerConverter()
        }
    };

    public async Task<Requests.Models.Request> GetRequest(long requestId, bool asNoTracking = true,
        CancellationToken cancellationToken = default)
    {
        if (!asNoTracking) return await repository.GetRequest(requestId, asNoTracking, cancellationToken);

        var cachedRequest = await cache.GetStringAsync(requestId.ToString(), cancellationToken);
        if (!string.IsNullOrEmpty(cachedRequest))
            return JsonSerializer.Deserialize<Requests.Models.Request>(cachedRequest, _options)!;

        var request = await repository.GetRequest(requestId, asNoTracking, cancellationToken);

        await cache.SetStringAsync(requestId.ToString(), JsonSerializer.Serialize(request, _options),
            cancellationToken);

        return request;
    }

    public async Task<Requests.Models.Request> CreateReques(Requests.Models.Request request,
        CancellationToken cancellationToken = default)
    {
        await repository.CreateReques(request, cancellationToken);

        await cache.SetStringAsync(request.Id.ToString(), JsonSerializer.Serialize(request, _options),
            cancellationToken);

        return request;
    }

    public async Task<bool> DeleteRequest(long requestId, CancellationToken cancellationToken = default)
    {
        await repository.DeleteRequest(requestId, cancellationToken);

        await cache.RemoveAsync(requestId.ToString(), cancellationToken);

        return true;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await repository.SaveChangesAsync(cancellationToken);

        // FIXME: This is a temporary fix to clear the cache after saving changes.
        //if (1 == 1) await cache.RemoveAsync("all_requests", cancellationToken);

        return result;
    }
}