using OrderFlow.Data;
using OrderFlow.Services;
using OrderFlow.Models;

var orders = SampleData.Orders;

// VALIDATOR
var validator = new OrderValidator();
validator.AddRule(OrderValidator.HasItems);
validator.AddRule(OrderValidator.PositiveQuantity);
validator.AddRule(OrderValidator.MaxAmount);

validator.AddFuncRule(o => o.Date <= DateTime.Now);
validator.AddFuncRule(o => o.Status != OrderStatus.Cancelled);

var validation = validator.ValidateAll(orders[0]);

Console.WriteLine("Validation:");
validation.ForEach(Console.WriteLine);

// PROCESSOR
var processor = new OrderProcessor(orders);

var filtered = processor.Filter(o => o.TotalAmount > 100);

processor.Execute(o => Console.WriteLine($"Order {o.Id}: {o.TotalAmount}"));

// LINQ
var join = orders.Join(SampleData.Customers,
    o => o.Customer.Id,
    c => c.Id,
    (o, c) => new { o.Id, c.City });

foreach (var j in join)
    Console.WriteLine($"{j.Id} - {j.City}");