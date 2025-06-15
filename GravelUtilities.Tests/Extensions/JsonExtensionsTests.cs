using System;
using System.Text.Json;
using Gravel.Utilities.Extensions;
using Gravel.Utilities.Tests.Models;
using Xunit;

namespace Gravel.Utilities.Tests.Extensions;

public class JsonExtensionsTests
{
    [Fact]
    public void JsonExtensions_ToJson_SerializesAndDeserializeObject()
    {
        var testObject = new ClassForTesting()
        {
            StringProperty = " Some String ",
            IntProperty = 1234,
            BoolProperty = true,
            SubClassForTesting = new SubClassForTesting()
            {
                SubStringProperty = "Sub String",
                SubIntProperty = 5678,
                SubBoolProperty = false
            }
        };

        var json  =testObject.ToJson();
        Assert.Equal("{\"stringProperty\":\"Some String\",\"intProperty\":1234,\"boolProperty\":true,\"dateProperty\":null,\"subClassForTesting\":{\"subStringProperty\":\"Sub String\",\"subIntProperty\":5678,\"subBoolProperty\":false}}", json);

        var deserializedJson = json.ToObject<ClassForTesting>();
        Assert.Equal(testObject.StringProperty.Trim(), deserializedJson.StringProperty);
        Assert.Equal(testObject.IntProperty, deserializedJson.IntProperty);
        Assert.Equal(testObject.BoolProperty, deserializedJson.BoolProperty);
        Assert.Equal(testObject.DateProperty, deserializedJson.DateProperty);
        Assert.Equal(testObject.SubClassForTesting.SubStringProperty, deserializedJson.SubClassForTesting.SubStringProperty);
        Assert.Equal(testObject.SubClassForTesting.SubIntProperty, deserializedJson.SubClassForTesting.SubIntProperty);
        Assert.Equal(testObject.SubClassForTesting.SubBoolProperty, deserializedJson.SubClassForTesting.SubBoolProperty);
    }

    [Fact]
    public void JsonSerializeOption_DateTime_DoesNotChangeUtc()
    {
        DateTime expectedDate = new(2025, 12, 10, 5, 38, 15, DateTimeKind.Utc);
        const string jsonString = "{\"dateProperty\":\"2025-12-10T05:38:15Z\"}";

        var result = jsonString.ToObject<ClassForTesting>();
        Assert.Equal(expectedDate, result.DateProperty);
    }
    
    [Fact]
    public void JsonSerializeOption_DateTime_AssumesUtc()
    {
        DateTime expectedDate = new(2025, 12, 10, 5, 38, 15, DateTimeKind.Utc);
        const string jsonString = "{\"dateProperty\":\"2025-12-10T05:38:15\"}";

        var result = jsonString.ToObject<ClassForTesting>();
        Assert.Equal(expectedDate, result.DateProperty);
    }
    
    [Fact]
    public void JsonSerializeOption_DateTime_DoesNotChangeUtc_WithOffsetPlus()
    {
        DateTime expectedDate = new(2025, 12, 10, 2, 38, 15, 123, DateTimeKind.Utc);
        const string jsonString = "{\"dateProperty\":\"2025-12-10T05:38:15.123+03:00\"}";

        var result = jsonString.ToObject<ClassForTesting>();
        Assert.Equal(expectedDate, result.DateProperty);
    }
    
    
    [Fact]
    public void JsonSerializeOption_DateTime_DoesNotChangeUtc_WithOffsetMinus()
    {
        DateTime expectedDate = new(2025, 12, 10, 8, 38, 15, 123, DateTimeKind.Utc);
        const string jsonString = "{\"dateProperty\":\"2025-12-10T05:38:15.123-03:00\"}";

        var result = jsonString.ToObject<ClassForTesting>();
        Assert.Equal(expectedDate, result.DateProperty);
    }
    
    [Fact]
    public void JsonSerializeOption_DateTime_DoesNotChangeUtc_StringHasWhiteSpace()
    {
        DateTime expectedDate = new(2025, 12, 10, 5, 38, 15, 123, DateTimeKind.Utc);
        const string jsonString = "{\"dateProperty\":\"2025-12- 10T05:38:15.123Z\"}";

        var result = jsonString.ToObject<ClassForTesting>();
        Assert.Equal(expectedDate, result.DateProperty);
    }
    
    
    [Fact]
    public void JsonSerializeOption_DateTime_Null_Optional()
    {
        const string jsonString = "{\"dateProperty\":null}";

        var result = jsonString.ToObject<ClassForTesting>();
        Assert.Null(result.DateProperty);
    }
    
    [Fact]
    public void JsonSerializeOption_DateTime_Null_Required()
    {
        const string jsonString = "{\"dateProperty\":null}";

        var result = () => jsonString.ToObject<DateTimeRequired>();
        var error = Assert.Throws<JsonException>(result);
        Assert.Equal("Null or Empty DateTime provided.", error.Message);
    }

    private class DateTimeRequired
    {
        public DateTime DateProperty { get; set; }
    }
}