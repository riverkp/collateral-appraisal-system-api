namespace Request.Requests.Events;

public record RequestCreatedEvent(Models.Request Request) : IDomainEvent;