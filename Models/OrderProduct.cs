namespace IoTBay.Models;

public class OrderProduct
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }

    public OrderProduct(int orderId, Order order, int productId, Product product)
    {
        OrderId = orderId;
        Order = order;
        ProductId = productId;
        Product = product;
    }
}