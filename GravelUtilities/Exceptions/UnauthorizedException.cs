using Microsoft.AspNetCore.Http;

namespace Gravel.Utilities.Exceptions;

public class UnauthorizedException : BaseException
{
    public UnauthorizedException(string message, string logMessage = null, Dictionary<string, object> errorContent = null)
        : base(message, StatusCodes.Status401Unauthorized, logMessage, errorContent)
    {
    }
}