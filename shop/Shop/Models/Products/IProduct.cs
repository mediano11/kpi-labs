using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    interface IProduct
    {
        int ProductID { get; }
        string ProductName { get; }
        decimal ProductPrice { get; }
    }
}
