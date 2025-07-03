using Shared.Exceptions;

namespace Request.Requests.Exceptions;

public class UploadDocumentException(string fileName, string message) : BadRequestException($"[{fileName}] {message}")
{
}