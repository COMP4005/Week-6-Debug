using System;
using System.Collections.Generic;

namespace DebuggerDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cart = new ShoppingCart();

            cart.AddItem(new Item("Laptop", 999.99m, 1));
            cart.AddItem(new Item("Mouse", 25.50m, 2));
            cart.AddItem(new Item("Keyboard", 45.00m, 1));

            decimal total = cart.CalculateTotal(discountPercent: 10);

            Console.WriteLine($"Total price: £{total}");
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Item(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    public class ShoppingCart
    {
        private readonly List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public decimal CalculateTotal(decimal discountPercent)
        {
            decimal subtotal = 0;

            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                subtotal += item.Price * item.Quantity;
            }

            decimal discountAmount = subtotal * (discountPercent / 100);
            decimal finalTotal = subtotal - discountAmount;

            return finalTotal;
        }
    }
}