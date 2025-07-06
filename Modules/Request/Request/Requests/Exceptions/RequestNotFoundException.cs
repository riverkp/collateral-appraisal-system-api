using Shared.Exceptions;

namespace Request.Requests.Exceptions;

public class RequestNotFoundException(long id) : NotFoundException("Request", id)
{
}