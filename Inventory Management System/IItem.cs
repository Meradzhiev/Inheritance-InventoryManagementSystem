using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public interface IItem
    {
        string GetDetails();
        decimal CalculateValue();
        string DisplayDescription();
    }
}
