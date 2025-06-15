using System.Text.Json.Serialization;

namespace Gravel.Utilities.Exceptions;

public class BaseException : Exception
{
    public int StatusCode { get; set; } = 500; // default to internal error
    public string LogMessage { get; set; }
    [JsonExtensionData]
    public Dictionary<string, object> ErrorContent { get; set; }

    public BaseException(string message, int? statusCode = null, string logMessage = null,
        Dictionary<string, object> errorContent = null) : base(message)
    {
        StatusCode = statusCode ?? StatusCode;
        LogMessage = logMessage;
        ErrorContent = errorContent;
    }
    
    public BaseException(string message, int statusCode, string logMessage = null,
        Dictionary<string, object> errorContent = null) : base(message)
    {
        StatusCode = statusCode;
        LogMessage = logMessage;
        ErrorContent = errorContent;
    }
}