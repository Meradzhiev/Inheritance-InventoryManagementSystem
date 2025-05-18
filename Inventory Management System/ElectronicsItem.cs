using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public class ElectronicsItem : InventoryItem
    {
        public string Brand { get; set; }

        public ElectronicsItem(int id, string name, string brand, decimal price, int quantity)
            : base(id, name, "Electronics", price, quantity, true, false)
        {
            Brand = brand;
        }

        public override string GetDetails() =>
            $"{base.GetDetails()}, Brand: {Brand}";
    }
}
