using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public interface ICategorizable
    {
        void SetCategory(string category);
        string GetCategory();
    }
}
