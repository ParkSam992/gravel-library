using Microsoft.AspNetCore.Http;

namespace Gravel.Utilities.Exceptions;

public class InvalidRequestException : BaseException
{
    public InvalidRequestException(string message, string logMessage = null, Dictionary<string, object> errorContent = null)
        : base(message, StatusCodes.Status422UnprocessableEntity, logMessage, errorContent)
    {
    }
}