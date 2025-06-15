using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Gravel.Utilities.Converters;

public class DateTimeConverter : JsonConverter<DateTime>
{
    private static readonly Regex whitespece = new Regex(@"\s+");
    private static readonly Regex localOffsetRegex = new Regex(@"[-+][0-9]{2}:[0-9]{2}");
    
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var input = reader.GetString();
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new JsonException("Null or Empty DateTime provided.");
        }
        
        // trim whitespace before converting
        input = whitespece.Replace(input, "");

        // if last character is 'Z' we dont need to convert format
        var lastChar = input.Substring(input.Length - 1);
        if (lastChar.Equals("Z", StringComparison.InvariantCultureIgnoreCase))
        {
            return DateTime.Parse(input).ToUniversalTime();
        }
        
        // if there is an offset, then convert before changing format
        if (localOffsetRegex.IsMatch(input))
        {
            return DateTime.Parse(DateTime.Parse(input).ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ")).ToUniversalTime();
        }
        
        // assume string is already in UTC
        return DateTime.Parse(DateTime.Parse(input).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ")).ToUniversalTime();
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ"));
    }
}