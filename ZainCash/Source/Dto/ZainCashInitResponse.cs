namespace Infrastructure.EPay;

public class ZainCashInitResponse
{
    public required string Id { get; set; }
    public required string Source { get; set; }
    public required string Type { get; set; }
    public required string To { get; set; }
    public required string ServiceType { get; set; }
    public required string OrderId { get; set; }
    public required string Amount { get; set; }
    public bool Credit { get; set; }
    public bool Reversed { get; set; }
    public required string ReferenceNumber { get; set; }
    public required string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string PaymentUrl { get; set; }
}