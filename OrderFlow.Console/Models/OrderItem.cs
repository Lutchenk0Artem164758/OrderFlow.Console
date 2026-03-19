namespace OrderFlow.Models;

public record OrderItem(Product Product, int Quantity)
{
    public decimal TotalPrice => Product.Price * Quantity;
}