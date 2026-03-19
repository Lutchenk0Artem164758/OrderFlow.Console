using OrderFlow.Models;

namespace OrderFlow.Data;

public static class SampleData
{
    public static List<Product> Products = new()
    {
        new Product(1, "Laptop", "Electronics", 5000),
        new Product(2, "Mouse", "Electronics", 100),
        new Product(3, "Desk", "Furniture", 800),
        new Product(4, "Chair", "Furniture", 600),
        new Product(5, "Headphones", "Electronics", 300)
    };

    public static List<Customer> Customers = new()
    {
        new Customer(1, "Jan", "Warsaw", true),
        new Customer(2, "Anna", "Krakow", false),
        new Customer(3, "Piotr", "Warsaw", false),
        new Customer(4, "Eva", "Gdansk", true)
    };

    public static List<Order> Orders = new()
    {
        new Order {
            Id = 1,
            Customer = Customers[0],
            Date = DateTime.Now.AddDays(-1),
            Status = OrderStatus.New,
            Items = new() {
                new OrderItem(Products[0],1),
                new OrderItem(Products[1],2)
            }
        },
        new Order {
            Id = 2,
            Customer = Customers[1],
            Date = DateTime.Now,
            Status = OrderStatus.Completed,
            Items = new() {
                new OrderItem(Products[2],1)
            }
        },
        new Order {
            Id = 3,
            Customer = Customers[2],
            Date = DateTime.Now,
            Status = OrderStatus.Cancelled,
            Items = new() {
                new OrderItem(Products[3],2)
            }
        },
        new Order {
            Id = 4,
            Customer = Customers[3],
            Date = DateTime.Now,
            Status = OrderStatus.Processing,
            Items = new() {
                new OrderItem(Products[4],3)
            }
        },
        new Order {
            Id = 5,
            Customer = Customers[0],
            Date = DateTime.Now,
            Status = OrderStatus.New,
            Items = new() {
                new OrderItem(Products[1],5)
            }
        },
        new Order {
            Id = 6,
            Customer = Customers[1],
            Date = DateTime.Now,
            Status = OrderStatus.Validated,
            Items = new() {
                new OrderItem(Products[0],1)
            }
        }
    };
}