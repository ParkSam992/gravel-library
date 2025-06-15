using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravel.Utilities.Converters;

public class StringConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString()?.Trim();
    }
    
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    { 
        writer.WriteStringValue(value?.Trim());
    }
}