using System.Collections.Generic;
using TutorialsTeachersLinq.Entities;
using System.Linq;
using System;

namespace TutorialsTeachersLinq.Demos
{
    class LinqQueries
    {
        internal static void GetCustomerOrders()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Mary" },
                new Customer { Id = 2, Name = "Joe" }
            };

            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Id = 10,
                    CustomerId = 1,
                    Orders = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Id = 1,
                            Product = new Product
                            {                                
                                Name = "Book",
                                Price = 4.5m
                            },
                            Quantity = 2
                        },
                        new OrderLine
                        {
                            Id = 2,
                            Product = new Product
                            {                                
                                Name = "Pen",
                                Price = 4.5m
                            },
                            Quantity = 2
                        },
                    }
                },
                new Order
                {
                    Id = 11,
                    CustomerId = 2,
                    Orders = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Id = 1,
                            Product = new Product
                            {
                                Name = "Bag",
                                Price = 10m
                            },
                            Quantity = 2
                        }                        
                    }
                }
            };

            // Get customer by name.
            var customer = customers.FirstOrDefault(c => c.Name == "Mary");

            var custOrders1 = orders.Where(c => c.CustomerId == customer.Id).SelectMany(s => s.Orders).ToList();

            // Do another query using a join.
            //..................
            var custOrders2 = orders.Where(c => c.CustomerId == customer.Id).Select( c => new
                                                                    {
                                                                       // This is where can do a join ???
                                                                       OrderCount = c.Orders.Count()
                                                                    }).ToList();

            Console.WriteLine($"Customer Name: {customer.Name}\n");
            
            foreach (var orderLine in custOrders1)
            {                
                Console.WriteLine($"OrderLine: {orderLine.Id}, Product: " +
                    $"{orderLine.Product.Name}, Quantity: {orderLine.Quantity}");
            }
            
        }
    }
}
