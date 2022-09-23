namespace RestClientPlayground;

public class HeaderDef
{
    public HeaderDef(string key, string value)
    {
        Key = key;
        Value = value;
    }
    public string Key { get; }
    public string Value { get; }
}

public interface IRestClient
{
    Task<TResponse?> GetAsync<TResponse>(string baseUri, string path, IList<HeaderDef>? headers = null);

    Task<TResponse?> PostAsync<TRequest, TResponse>(TRequest request, string baseUri, string path,
        IList<HeaderDef>? headers = null);
}