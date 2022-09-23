using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestClientPlayground;

public class JsonHelper
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
    
    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}