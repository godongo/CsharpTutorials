using ImplementDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImplementDataAccess.Demos
{
    class UsingLINQ
    {
        internal static void SimpleDelegate()
        {
            // Remember Delegate is a type that references a method.
            // Anonymous method example or simply a nameless method.
            Func<int, int> myDelegate = delegate (int x)
                                        {
                                            return x * 2;
                                        };

            // Fun<T, T>    - Has return type.
            // Action<T, T> - No return type.

            // Shorthand for writing delegates
            Func<int, int> myLambda = x => x * 2;

            // myDelegate variable can now be PASSED ARROUND            
            Console.WriteLine($"myDelegate: {myDelegate(21)}");
            Console.WriteLine($"myLambda: {myLambda(21)}");
        }

        internal static void SimpleAnonymousType()
        {
            var person = new
            {
                FirstName = "George",
                LastName = "Odongo"
            };

            Console.WriteLine(person.GetType().Name);
        }

        internal static void SelectOperator()
        {
            int[] data = { 1, 2, 5, 8, 11 };

            var result = from d in data
                         select d;


        }

        internal static void WhereOperator()
        {
            int[] data = { 1, 2, 5, 8, 11 };

            //var result = data.Where(d => d % 2 == 0);
            var result = from d in data
                         where d > 5
                         select d;

            Console.WriteLine(string.Join(",", result));
        }

        internal static void OrderbyOperator()
        {
            int[] data = { 1, 2, 5, 8, 11 };

            //var result = data.Where(d => d % 2 == 0);
            var result = from d in data
                         where d > 5
                         orderby d descending
                         select d;

            Console.WriteLine(string.Join(",", result));
        }

        internal static void CombiningDataSources()
        {
            int[] data1 = { 1, 2, 5 };
            int[] data2 = { 2, 4, 6 };

            var result = from d1 in data1
                         from d2 in data2
                         select d1 * d2;

            Console.WriteLine(string.Join(",", result));
        }

        // Average number of OrderLines for a set of Orders.
        internal static void AverageOperator()
        {
            // No query syntax for the Average method, which is why you need to use the method syntax.
            var averageNumberOfOrderLines = GetOrders().Average(o => o.OrderLines.Count);

            Console.WriteLine($"Average Order {averageNumberOfOrderLines}");
        }

        internal static void GroupingAndProjectionOperators()
        {
            var result = from o in GetOrders()
                         from l in o.OrderLines
                         group l by l.Product into p                         
                         select new
                         {
                             Product = p.Key,
                             Amount = p.Sum(x => x.Amount)
                         };

            foreach (var item in result)
            {
                Console.WriteLine($" Product Description: {item.Product.Description} and { item.Amount } ");
            }
            
        }

        // Used to combine data from two or more sources
        internal static void JoinOperator()
        {
            string[] popularProductNames = { "Pen", "Book", "Staples" };

            var popularProducts = from p in GetProducts()
                                  join n in popularProductNames on p.Description equals n
                                  select p;

            foreach (var p in popularProducts)
            {
                Console.WriteLine($"Description: {p.Description} and Price: {p.Price}");
            }
        }

        internal static void CustomWhereOperator()
        {
            string[] cities = { "London", "Paris", "Berlin", "Brussels", "New York", "Madrid" };

            var result = cities.MyWhere(x => x.StartsWith("B")).First() ;

            //foreach (var p in result)
            //{
            //    Console.WriteLine(string.Join(",", result));
            //}
            Console.WriteLine(result);
        }
        


        private static List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Amount = 2,
                            Product = new Product
                            {
                                Description = "Pen",
                                Price = 2m
                            }
                        },
                        new OrderLine
                        {
                            Amount = 3,
                            Product = new Product
                            {
                                Description = "Book",
                                Price = 2.5m
                            }
                        },
                        new OrderLine
                        {
                            Amount = 2,
                            Product = new Product
                            {
                                Description = "Magazine",
                                Price = 3.5m
                            }
                        }
                    }
                },
                new Order
                {
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Amount = 2,
                            Product = new Product
                            {
                                Description = "Pen",
                                Price = 2m
                            }
                        }                       
                    }
                }
            };   
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Description = "Pen",
                    Price = 2m
                },
                new Product
                {
                    Description = "Book",
                    Price = 2.5m
                },
                new Product
                {
                    Description = "Magazine",
                    Price = 3.5m
                }
            };

        }
    }
}
