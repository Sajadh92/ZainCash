namespace Infrastructure.EPay;

public class ZainCashPayResponse
{
    public bool IsSuccess { get; set; }
    public required string Status { get; set; }
    public required string Msg { get; set; }
    public required string OrderId { get; set; }
    public required string Id { get; set; }
}