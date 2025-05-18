using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public static class InventoryFileManager
    {
        private static readonly string FilePath = "inventory.txt";

        public static void SaveInventory(List<InventoryItem> items)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var item in items)
                {
                    writer.WriteLine($"{item.Id},{item.Name},{item.Category},{item.Price},{item.Quantity}");
                }
            }
        }

        public static List<InventoryItem> LoadInventory()
        {
            var items = new List<InventoryItem>();
            if (!File.Exists(FilePath)) return items;

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                items.Add(new InventoryItem(
                    id: int.Parse(parts[0]),
                    name: parts[1],
                    category: parts[2],
                    price: decimal.Parse(parts[3]),
                    quantity: int.Parse(parts[4]),
                    isBreakable: false,
                    isPerishable: false
                ));
            }
            return items;
        }
    }
}
