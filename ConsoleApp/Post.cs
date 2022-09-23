namespace RestClientPlayground;

public class Post
{
    public Post(int userId, string body, string title)
    {
        UserId = userId;
        Body = body;
        Title = title;
    }
    public int Id { get; init; }
    public int UserId { get; init; }
    public string Body { get; init; }
    public string Title { get; init; }
    public override string ToString()
    {
        return $"{Id}, {UserId}, {Body}, {Title}";
    }
}