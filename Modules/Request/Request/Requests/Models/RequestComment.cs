namespace Request.Requests.Models;

public class RequestComment : Entity<long>
{

    private RequestComment()
    {
    }

    private RequestComment(string comment)
    {
        Comment = comment;
    }
    public string Comment { get; private set; } = default!;

    public static RequestComment Create(string comment)
    {
        ArgumentException.ThrowIfNullOrEmpty(comment);

        return new RequestComment(comment);
    }
}