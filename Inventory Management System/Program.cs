using Inventory_Management_System;

public class Program
{
    private static List<InventoryItem> _inventory = new List<InventoryItem>();

    public static void Main()
    {
        try
        {
            LoadInventory();
            RunMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
            Console.WriteLine("Application will now exit.");
            Environment.Exit(1);
        }
    }
    private static void RunMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Inventory Management System ---");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. List Items");
            Console.WriteLine("3. Place Order");
            Console.WriteLine("4. Search Items");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddItem(); break;
                case "2": ListItems(); break;
                case "3": PlaceOrder(); break;
                case "4": SearchItems(); break;
                case "5": SaveAndExit(); return;
                default: Console.WriteLine("Invalid choice!"); break;
            }
        }
    }

    private static void AddItem()
    {
        Console.Write("Enter item category (1=Electronics, 2=Grocery, 3=Fragile): ");
        string type = Console.ReadLine();

        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        InventoryItem item = null;
        switch (type)
        {
            case "1":
                Console.Write("Enter Brand: ");
                string brand = Console.ReadLine();
                item = new ElectronicsItem(id, name, brand, price, quantity);
                break;
            case "2":
                Console.Write("Enter Expiry Date (yyyy-mm-dd): ");
                DateTime expiry = DateTime.Parse(Console.ReadLine());
                item = new GroceryItem(id, name, price, quantity, expiry);
                break;
            case "3":
                Console.Write("Enter Weight (kg): ");
                double weight = double.Parse(Console.ReadLine());
                item = new FragileItem(id, name, price, quantity, weight);
                break;
        }

        if (item != null)
        {
            _inventory.Add(item);
            Console.WriteLine("Item added successfully!");
        }
    }

    private static void ListItems()
    {
        foreach (var item in _inventory)
            Console.WriteLine(item.GetDetails());
    }

    private static void PlaceOrder()
    {
        Console.Write("Enter Item ID: ");
        int id = int.Parse(Console.ReadLine());

        var item = _inventory.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            Console.WriteLine("Item not found!");
            return;
        }

        Console.Write("Enter Quantity: ");
        int qty = int.Parse(Console.ReadLine());

        if (qty > item.Quantity)
        {
            Console.WriteLine("Not enough stock!");
            return;
        }

        item.Quantity -= qty;
        decimal total = item.GetPrice() * qty;
        Console.WriteLine($"Order placed! Total: {total:C}");
    }

    private static void LoadInventory() => _inventory = InventoryFileManager.LoadInventory();
    private static void SaveInventory() => InventoryFileManager.SaveInventory(_inventory);

    private static void SearchItems()
    {
        Console.Write("Enter search term: ");
        string searchTerm = Console.ReadLine()?.ToLower();

        var results = _inventory.Where(item => item.Name.ToLower().Contains(searchTerm)).ToList();

        if (results.Any())
        {
            Console.WriteLine("\nSearch Results:");
            foreach (var item in results)
            {
                Console.WriteLine(item.GetDetails());
            }
        }
        else
        {
            Console.WriteLine("No items found matching the search term.");
        }
    }
    private static void SaveAndExit()
    {
        SaveInventory();
        Console.WriteLine("Inventory saved. Exiting application...");
        Environment.Exit(0);
    }
}