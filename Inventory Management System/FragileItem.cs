using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public class FragileItem : InventoryItem
    {
        public double Weight { get; set; }

        public FragileItem(int id, string name, decimal price, int quantity, double weight)
            : base(id, name, "Fragile", price, quantity, true, false)
        {
            Weight = weight;
        }

        public override string GetDetails() =>
            $"{base.GetDetails()}, Weight: {Weight}kg";
    }
}
