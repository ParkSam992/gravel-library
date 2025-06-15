using System.Text.Json;
using Gravel.Utilities.Constants;

namespace Gravel.Utilities.Extensions;

public static class JsonExtensions
{
    public static string ToJson<T>(this T t)
    {
        return JsonSerializer.Serialize(t, GravelConstants.SERIALIZER_OPTIONS);
    }

    public static T ToObject<T>(this string jsonString)
    {
        return JsonSerializer.Deserialize<T>(jsonString, GravelConstants.SERIALIZER_OPTIONS);
    }
}