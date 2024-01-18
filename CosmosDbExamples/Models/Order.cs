namespace CosmosDbExamples.Models;

public class Order
{
    public int Id { get; set; }
    public int? TrackingNumber { get; set; }
    public string PartitionKey { get; set; } = string.Empty;
    public StreetAddress? ShippingAddress { get; set; }
}