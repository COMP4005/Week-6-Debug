class Program
{
    private static void Main(string[] args)
    {
        ShoppingCart cart = new ShoppingCart();

        cart.AddItem(new Item("Laptop", 999.99m, 1));
        cart.AddItem(new Item("Mouse", 25.50m, 2));
        cart.AddItem(new Item("Keyboard", 45.00m, 1));

        decimal total = cart.CalculateTotal();

        Console.WriteLine($"Total price: £{total}");
    }
}

public class Item
{
    public string name;
    public decimal price;
    public int quantity;

    public Item(string name, decimal price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }
}

public class ShoppingCart
{
    private readonly List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public decimal CalculateTotal()
    {
        decimal subtotal = 0;

        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            subtotal += item.price * item.quantity;
        }

        return subtotal;
    }
}