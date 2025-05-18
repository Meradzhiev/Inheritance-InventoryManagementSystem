using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public interface ISellable
    {
        void SetPrice(decimal price);
        decimal GetPrice();
    }
}
