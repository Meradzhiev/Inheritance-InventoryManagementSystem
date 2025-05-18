using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public class InventoryItem : AbstractItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public InventoryItem(int id, string name, string category, decimal price, int quantity, bool isBreakable, bool isPerishable)
            : base(name, category, price, isBreakable, isPerishable)
        {
            Id = id;
            Quantity = quantity;
        }

        public override decimal CalculateValue() => Price * Quantity;

        public override string GetDetails() =>
            $"{base.GetDetails()}, ID: {Id}, Quantity: {Quantity}";
    }
}
