using System.Text.Json;
using Gravel.Utilities.Converters;

namespace Gravel.Utilities.Constants;

public class GravelConstants
{
    public static readonly JsonSerializerOptions SERIALIZER_OPTIONS = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new StringConverter(), new DateTimeConverter() }
    };
}