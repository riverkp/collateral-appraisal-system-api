namespace Request.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Requests.Models.Request> Requests => new List<Requests.Models.Request>
    {
        new Requests.Models.Request
        (
            new Guid(),
            "Purpose 1",
            "Channel 1"
        ),

        new Requests.Models.Request
        (
            new Guid(),
            "Purpose 2",
            "Channel 2"
        )
    };
}
