using OrderFlow.Models;

namespace OrderFlow.Models;

public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public DateTime Date { get; set; }
    public OrderStatus Status { get; set; }

    public decimal TotalAmount => Items.Sum(i => i.TotalPrice);
}