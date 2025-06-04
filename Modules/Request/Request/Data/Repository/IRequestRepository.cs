namespace Request.Data.Repository;

public interface IRequestRepository
{
    Task<Requests.Models.Request> GetRequest(Guid requestId, bool asNoTracking = true, CancellationToken cancellationToken = default);
    Task<Requests.Models.Request> CreateReques(Requests.Models.Request request, CancellationToken cancellationToken = default);
    Task<bool> DeleteRequest(Guid requestId, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
