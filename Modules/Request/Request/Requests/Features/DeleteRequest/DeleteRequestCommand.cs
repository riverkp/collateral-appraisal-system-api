namespace Request.Requests.Features.DeleteRequest;

public record DeleteRequestCommand(long Id) : ICommand<DeleteRequestResult>;