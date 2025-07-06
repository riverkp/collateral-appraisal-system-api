namespace Request.Requests.ValueObjects;

public record RequestStatus
{
    public string Code { get; }
    public static RequestStatus Draft => new(nameof(Draft).ToUpper());
    public static RequestStatus New => new(nameof(New).ToUpper());

    private RequestStatus(string code)
    {
        Code = code;
    }

    public override string ToString() => Code;
    public static implicit operator string(RequestStatus requestStatus) => requestStatus.Code;
}