using OrderFlow.Models;

namespace OrderFlow.Services;

public class OrderProcessor
{
    private List<Order> _orders;

    public OrderProcessor(List<Order> orders)
    {
        _orders = orders;
    }

    public List<Order> Filter(Predicate<Order> predicate)
        => _orders.Where(o => predicate(o)).ToList();

    public void Execute(Action<Order> action)
    {
        foreach (var o in _orders)
            action(o);
    }

    public List<T> Select<T>(Func<Order, T> selector)
        => _orders.Select(selector).ToList();

    public decimal Aggregate(Func<IEnumerable<Order>, decimal> func)
        => func(_orders);
}