using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    abstract public class Product : IProduct
    {
        public int ProductID { get; }
        public string ProductName { get; }
        public decimal ProductPrice { get; }

        public Product(int productID, string productName, decimal productPrice)
        {
            ProductID = productID;
            ProductName = productName;
            ProductPrice = productPrice;
        }
        public String toRow()
        {
            return String.Format("| {0,-12}| {1,-20}|{2,14:C2} |", this.ProductID, this.ProductName, this.ProductPrice);
        }
        public abstract String toString();
    }
}
