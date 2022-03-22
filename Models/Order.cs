using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;

public enum OrderStatus
{
    Processing,
    Picking,
    Packing,
    OnboardForDelivery
}

public class Order
{
    public int Id { get; set; }

    [MaxLength(63)]
    public string Address { get; set; }

    [MaxLength(255)]
    public string DeliveryInstructions { get; set; }

    public DateTime DateOrdered { get; private set; }

    public DateTime LastUpdate { get; set; }

    public OrderStatus Status { get; set; }

    public ICollection<OrderProduct> Products { get; set; }

    public int? CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public Order(string address, string deliveryInstructions)
    {
        Address = address;
        DeliveryInstructions = deliveryInstructions;
        DateOrdered = DateTime.Now;
        LastUpdate = DateTime.Now;
        Status = OrderStatus.Processing;
        Products = new List<OrderProduct>();
    }
}