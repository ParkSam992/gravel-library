using Microsoft.AspNetCore.Http;

namespace Gravel.Utilities.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message, string logMessage = null, Dictionary<string, object> errorContent = null)
        : base(message, StatusCodes.Status404NotFound, logMessage, errorContent)
    {
    }
}