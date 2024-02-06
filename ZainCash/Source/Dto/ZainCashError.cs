namespace Infrastructure.EPay;

public class ZainCashError
{
    public required ZainCashErrorDetails Err { get; set; }
}

public class ZainCashErrorDetails
{
    public required string Msg { get; set; }
}
