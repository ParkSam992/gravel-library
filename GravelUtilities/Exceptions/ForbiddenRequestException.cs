using Microsoft.AspNetCore.Http;

namespace Gravel.Utilities.Exceptions;

public class ForbiddenRequestException : BaseException
{
    public ForbiddenRequestException(string message, string logMessage = null, Dictionary<string, object> errorContent = null)
        : base(message, StatusCodes.Status403Forbidden, logMessage, errorContent)
    {
    }
}