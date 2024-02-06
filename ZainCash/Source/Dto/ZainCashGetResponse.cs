namespace Infrastructure.EPay;

public class ZainCashGetResponse
{
    public required To To { get; set; }
    public required string Source { get; set; }
    public required string Type { get; set; }
    public required string Amount { get; set; }
    public required string ServiceType { get; set; }
    public required string Lang { get; set; }
    public required string OrderId { get; set; }
    public required string ReferenceNumber { get; set; }
    public required string RedirectUrl { get; set; }
    public bool Credit { get; set; }
    public required string Status { get; set; }
    public bool Reversed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int SofOwnerId { get; set; }
    public required string TravelDiscount { get; set; }
    public required string From { get; set; }
    public required string OnCustomerFees { get; set; }
    public required string OnMerchantFees { get; set; }
    public int TotalFees { get; set; }
    public required string Due { get; set; }
    public required string Id { get; set; }
}

public class To
{
    public required string Name { get; set; }
    public required string Msisdn { get; set; }
    public required string Currency { get; set; }
    public bool Deleted { get; set; }
    public required string PayByReference { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Id { get; set; }
}