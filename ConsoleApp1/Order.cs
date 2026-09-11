using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Order : ICalculatable
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal CalculateTotal() => Items.Sum(item => item.CalculateTotal());

        public override string ToString() => $"Заказ №{Id} от {OrderDate:d} | Покупатель: {CustomerName} | Сумма: {CalculateTotal():C}";
    }
}