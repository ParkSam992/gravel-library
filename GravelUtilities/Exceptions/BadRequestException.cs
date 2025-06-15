using Microsoft.AspNetCore.Http;

namespace Gravel.Utilities.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string message, string logMessage = null, Dictionary<string, object> errorContent = null)
        : base(message, StatusCodes.Status400BadRequest, logMessage, errorContent)
    {
    }
}