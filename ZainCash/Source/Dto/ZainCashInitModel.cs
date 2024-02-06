namespace Infrastructure.EPay;

public class ZainCashInitModel
{
    public required string ServiceType { get; set; }
    public required string OrderId { get; set; }
    public required decimal Amount { get; set; }
}
