using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp;

public static class JsonHelper
{
    public static T? Deserialize<T>(string json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        options.Converters.Add(new JsonStringEnumConverter());

        return JsonSerializer.Deserialize<T>(json, options);
    }
}