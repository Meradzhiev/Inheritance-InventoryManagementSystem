using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public abstract class AbstractItem : IItem, ICategorizable, IBreakable, IPerishable, ISellable
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsBreakableItem { get; set; }
        public bool IsPerishableItem { get; set; }
        public decimal Price { get; set; }

        public AbstractItem(string name, string category, decimal price, bool isBreakable, bool isPerishable)
        {
            Name = name;
            Category = category;
            Price = price;
            IsBreakableItem = isBreakable;
            IsPerishableItem = isPerishable;
        }

        // IItem Methods
        public virtual string GetDetails() => $"Name: {Name}, Category: {Category}, Price: {Price:C}";
        public abstract decimal CalculateValue();
        public virtual string DisplayDescription() => GetDetails();

        // ICategorizable Methods
        public void SetCategory(string category) => Category = category;
        public string GetCategory() => Category;

        // IBreakable Methods
        public bool IsBreakable() => IsBreakableItem;
        public void HandleBreakage() => Console.WriteLine($"{Name} has broken!");

        // IPerishable Methods
        public bool IsPerishable() => IsPerishableItem;
        public void HandleExpiration() => Console.WriteLine($"{Name} has expired!");

        // ISellable Methods
        public void SetPrice(decimal price) => Price = price;
        public decimal GetPrice() => Price;
    }
}
