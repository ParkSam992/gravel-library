using Microsoft.AspNetCore.Http;

namespace Gravel.Utilities.Exceptions;

public class ConflictException : BaseException
{
    public ConflictException(string message, string logMessage = null, Dictionary<string, object> errorContent = null)
        : base(message, StatusCodes.Status409Conflict, logMessage, errorContent)
    {
    }
}