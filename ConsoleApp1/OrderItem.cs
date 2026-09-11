using System;

namespace ConsoleApp1
{
    public class OrderItem : ICalculatable
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal CalculateTotal() => Product.Price * Quantity;

        public override string ToString() => $"{Product.Name} x{Quantity} = {CalculateTotal():C}";
    }
}