using ConsoleApp;

var httpClient = new HttpClient();
var restClient = new RestClient(httpClient);

const string baseUri = "https://jsonplaceholder.typicode.com/";
var result = await restClient.GetAsync<IList<PostRead>>(baseUri,"posts");
if (result != null)
{
    foreach (var post in result)
    {
        Console.WriteLine(post);
    }
}

var newPost = new PostWrite(42,"The message", "Hello");
var postResult = await restClient.PostAsync<PostWrite,PostRead>(newPost, baseUri, "posts");
Console.WriteLine(postResult);