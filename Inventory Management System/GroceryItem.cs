using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public class GroceryItem : InventoryItem
    {
        public DateTime ExpiryDate { get; set; }

        public GroceryItem(int id, string name, decimal price, int quantity, DateTime expiryDate)
            : base(id, name, "Grocery", price, quantity, false, true)
        {
            ExpiryDate = expiryDate;
        }

        public override string GetDetails() =>
            $"{base.GetDetails()}, Expiry: {ExpiryDate:d}";

    }
}
