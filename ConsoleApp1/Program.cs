using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static List<Product> AllProducts = new List<Product>();
        static List<Order> Orders = new List<Order>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            InitializeData();

            while (true)
            {
                Console.WriteLine("\nМЕНЮ");
                Console.WriteLine("Все заказы");
                Console.WriteLine("Товары в заказах");
                Console.WriteLine("Стоимость каждого заказа");
                Console.WriteLine("Самый дорогой заказ");
                Console.WriteLine("Самый дешевый заказ");
                Console.WriteLine("Общая выручка");
                Console.WriteLine("Средняя стоимость заказа");
                Console.WriteLine("Заказы дороже суммы");
                Console.WriteLine("Заказанные товары");
                Console.WriteLine("Не заказанные товары");
                Console.WriteLine("Самый продаваемый товар");
                Console.WriteLine("Товар с макс. выручкой");
                Console.WriteLine("Кол-во заказов покупателей");
                Console.WriteLine("Сумма покупок покупателей");
                Console.WriteLine("Топ покупатель");
                Console.WriteLine("Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1": Task1_ShowAllOrders(); break;
                    case "2": Task2_ShowProductsInOrders(); break;
                    case "3": Task3_ShowTotalCostPerOrder(); break;
                    case "4": Task4_MostExpensiveOrder(); break;
                    case "5": Task5_CheapestOrder(); break;
                    case "6": Task6_TotalRevenue(); break;
                    case "7": Task7_AverageOrderCost(); break;
                    case "8":
                        Console.Write("Введите сумму: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                            Task8_OrdersAboveAmount(amount);
                        else
                            Console.WriteLine("Некорректная сумма.");
                        break;
                    case "9": Task9_OrderedProducts(); break;
                    case "10": Task10_UnorderedProducts(); break;
                    case "11": Task11_BestSellingProduct(); break;
                    case "12": Task12_MostProfitableProduct(); break;
                    case "13": Task13_OrdersCountPerCustomer(); break;
                    case "14": Task14_TotalSpentPerCustomer(); break;
                    case "15": Task15_TopSpender(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный пункт."); break;
                }
                
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        
        static void InitializeData()
        {
            AllProducts.Add(new Product { Id = 1, Name = "Ноутбук", Category = "Электроника", Price = 50000 });
            AllProducts.Add(new Product { Id = 2, Name = "Мышь", Category = "Электроника", Price = 1500 });
            AllProducts.Add(new Product { Id = 3, Name = "Клавиатура", Category = "Электроника", Price = 3000 });
            AllProducts.Add(new Product { Id = 4, Name = "Монитор", Category = "Электроника", Price = 15000 });
            AllProducts.Add(new Product { Id = 5, Name = "Книга C#", Category = "Книги", Price = 2000 });
            AllProducts.Add(new Product { Id = 6, Name = "Кружка", Category = "Посуда", Price = 500 });
            AllProducts.Add(new Product { Id = 7, Name = "Стол", Category = "Мебель", Price = 8000 });
            AllProducts.Add(new Product { Id = 8, Name = "Стул", Category = "Мебель", Price = 4000 });
            AllProducts.Add(new Product { Id = 9, Name = "Наушники", Category = "Электроника", Price = 2500 });

            Orders.Add(new Order { Id = 1, CustomerName = "Иван", OrderDate = DateTime.Now.AddDays(-10), Items = new List<OrderItem> { new OrderItem { Product = AllProducts[0], Quantity = 1 }, new OrderItem { Product = AllProducts[1], Quantity = 2 } } });
            Orders.Add(new Order { Id = 2, CustomerName = "Петр", OrderDate = DateTime.Now.AddDays(-9), Items = new List<OrderItem> { new OrderItem { Product = AllProducts[4], Quantity = 3 }, new OrderItem { Product = AllProducts[5], Quantity = 1 } } });
            Orders.Add(new Order { Id = 3, CustomerName = "Иван", OrderDate = DateTime.Now.AddDays(-8), Items = new List<OrderItem> { new OrderItem { Product = AllProducts[2], Quantity = 1 }, new OrderItem { Product = AllProducts[3], Quantity = 1 }, new OrderItem { Product = AllProducts[8], Quantity = 2 } } });
            Orders.Add(new Order { Id = 4, CustomerName = "Анна", OrderDate = DateTime.Now.AddDays(-7), Items = new List<OrderItem> { new OrderItem { Product = AllProducts[6], Quantity = 4 }, new OrderItem { Product = AllProducts[7], Quantity = 4 } } });
            Orders.Add(new Order { Id = 5, CustomerName = "Петр", OrderDate = DateTime.Now.AddDays(-6), Items = new List<OrderItem> { new OrderItem { Product = AllProducts[0], Quantity = 1 }, new OrderItem { Product = AllProducts[8], Quantity = 1 } } });
            Orders.Add(new Order { Id = 6, CustomerName = "Мария", OrderDate = DateTime.Now.AddDays(-5), Items = new List<OrderItem> { new OrderItem { Product = AllProducts[1], Quantity = 5 }, new OrderItem { Product = AllProducts[5], Quantity = 5 } } });
        }
        
        static void Task1_ShowAllOrders()
        {
            Console.WriteLine("--- Все заказы ---");
            foreach (var order in Orders) Console.WriteLine(order);
        }
        
        static void Task2_ShowProductsInOrders()
        {
            Console.WriteLine("--- Товары в заказах ---");
            foreach (var order in Orders)
            {
                Console.WriteLine($"Заказ №{order.Id}:");
                foreach (var item in order.Items) Console.WriteLine($"  {item}");
            }
        }
        
        static void Task3_ShowTotalCostPerOrder()
        {
            Console.WriteLine("--- Стоимость каждого заказа ---");
            foreach (var order in Orders) Console.WriteLine($"Заказ №{order.Id}: {order.CalculateTotal():C}");
        }
        
        static void Task4_MostExpensiveOrder()
        {
            var maxOrder = Orders.OrderByDescending(o => o.CalculateTotal()).FirstOrDefault();
            Console.WriteLine($"Самый дорогой заказ: №{maxOrder?.Id} на сумму {maxOrder?.CalculateTotal():C}");
        }
        
        static void Task5_CheapestOrder()
        {
            var minOrder = Orders.OrderBy(o => o.CalculateTotal()).FirstOrDefault();
            Console.WriteLine($"Самый дешевый заказ: №{minOrder?.Id} на сумму {minOrder?.CalculateTotal():C}");
        }
        
        static void Task6_TotalRevenue()
        {
            decimal total = Orders.Sum(o => o.CalculateTotal());
            Console.WriteLine($"Общая выручка магазина: {total:C}");
        }
        
        static void Task7_AverageOrderCost()
        {
            decimal avg = Orders.Average(o => o.CalculateTotal());
            Console.WriteLine($"Средняя стоимость заказа: {avg:C}");
        }
        
        static void Task8_OrdersAboveAmount(decimal amount)
        {
            var filtered = Orders.Where(o => o.CalculateTotal() > amount).ToList();
            Console.WriteLine($"--- Заказы дороже {amount:C} ---");
            if (filtered.Any()) filtered.ForEach(o => Console.WriteLine(o));
            else Console.WriteLine("Нет таких заказов.");
        }
        
        static void Task9_OrderedProducts()
        {
            var orderedProducts = Orders.SelectMany(o => o.Items)
                                        .Select(i => i.Product)
                                        .GroupBy(p => p.Id)
                                        .Select(g => g.First())
                                        .ToList();
            Console.WriteLine("--- Товары, которые заказывали ---");
            orderedProducts.ForEach(p => Console.WriteLine(p.Name));
        }
        
        static void Task10_UnorderedProducts()
        {
            var orderedIds = Orders.SelectMany(o => o.Items).Select(i => i.Product.Id).Distinct().ToList();
            var unordered = AllProducts.Where(p => !orderedIds.Contains(p.Id)).ToList();
            
            Console.WriteLine("--- Товары, которые не заказывали ---");
            if (unordered.Any()) unordered.ForEach(p => Console.WriteLine(p.Name));
            else Console.WriteLine("Все товары были заказаны.");
        }
        
        static void Task11_BestSellingProduct()
        {
            var bestSeller = Orders.SelectMany(o => o.Items)
                                   .GroupBy(i => i.Product)
                                   .Select(g => new { Product = g.Key, TotalQty = g.Sum(i => i.Quantity) })
                                   .OrderByDescending(x => x.TotalQty)
                                   .FirstOrDefault();
            Console.WriteLine($"Самый продаваемый товар: {bestSeller?.Product.Name} (продано {bestSeller?.TotalQty} шт.)");
        }
        
        static void Task12_MostProfitableProduct()
        {
            var topRevenue = Orders.SelectMany(o => o.Items)
                                   .GroupBy(i => i.Product)
                                   .Select(g => new { Product = g.Key, Revenue = g.Sum(i => i.CalculateTotal()) })
                                   .OrderByDescending(x => x.Revenue)
                                   .FirstOrDefault();
            Console.WriteLine($"Товар с наибольшей выручкой: {topRevenue?.Product.Name} ({topRevenue?.Revenue:C})");
        }
        
        static void Task13_OrdersCountPerCustomer()
        {
            var counts = Orders.GroupBy(o => o.CustomerName)
                               .Select(g => new { Name = g.Key, Count = g.Count() });
            Console.WriteLine("Количество заказов по покупателям:");
            foreach (var c in counts) Console.WriteLine($"{c.Name}: {c.Count}");
        }
        
        static void Task14_TotalSpentPerCustomer()
        {
            var totals = Orders.GroupBy(o => o.CustomerName)
                               .Select(g => new { Name = g.Key, Total = g.Sum(o => o.CalculateTotal()) });
            Console.WriteLine("Сумма покупок по покупателям:");
            foreach (var t in totals) Console.WriteLine($"{t.Name}: {t.Total:C}");
        }
        
        static void Task15_TopSpender()
        {
            var topSpender = Orders.GroupBy(o => o.CustomerName)
                                   .Select(g => new { Name = g.Key, Total = g.Sum(o => o.CalculateTotal()) })
                                   .OrderByDescending(x => x.Total)
                                   .FirstOrDefault();
            Console.WriteLine($"Больше всего потратил: {topSpender?.Name} ({topSpender?.Total:C})");
        }
    }
}