using System.Text.Json;

namespace RestClientPlayground;

public class RestClient : IRestClient
{
    private readonly HttpClient _httpClient;
    public RestClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TResponse?> GetAsync<TResponse>(string baseUri, string path, IList<HeaderDef>? headers = null)
    {
        using var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{baseUri}{path}"),
        };
        if (headers != null)
        {
            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }
        }

        var response = await _httpClient.SendAsync(httpRequestMessage);
        if (!response.IsSuccessStatusCode) throw new Exception($"Error code: {response.StatusCode}");
        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonHelper.Deserialize<TResponse>(responseBody);
        return result;
    }

    public async Task<TResponse?> PostAsync<TBody, TResponse>(TBody body, string baseUri, string path, IList<HeaderDef>? headers = null)
    {
        using var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri($"{baseUri}{path}"),
            Content = new StringContent(JsonSerializer.Serialize<TBody>(body))
        };
        if (headers != null)
        {
            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }
        }

        var response = await _httpClient.SendAsync(httpRequestMessage);
        if (!response.IsSuccessStatusCode) throw new Exception($"Error code: {response.StatusCode}");
        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonHelper.Deserialize<TResponse>(responseBody);
        return result;
    }
}
