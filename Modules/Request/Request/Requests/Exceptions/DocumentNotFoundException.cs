using Shared.Exceptions;

namespace Request.Requests.Exceptions;

public class DocumentNotFoundException(string name) : NotFoundException("Document Not Found", name)
{
}