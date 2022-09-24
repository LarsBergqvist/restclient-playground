namespace ConsoleApp;

public readonly record struct PostRead(int Id, int UserId, string Body, string Title);
public readonly record struct PostWrite(int UserId, string Body, string Title);
