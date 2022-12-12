using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Motorcycle : Product
    {
        public int CubicCentimeters{ get; }
        public int TankCapacity { get; }

        public Motorcycle(int productID, string productName, decimal productPrice, int cubicCentimeters, int tankCapacity) : base(productID, productName, productPrice)
        {
            CubicCentimeters = cubicCentimeters;
            TankCapacity = tankCapacity;
        }

        public override String toString()
        {
            var info = new StringBuilder();
            info.AppendLine(String.Format("| {0,-4}| {1,-20}| {2,-14:C2}| {3,-18}| {4,-14}|", "ID", "Motorcycle name", "Price", "Cubic centimeters", "Tank capacity"));
            info.AppendLine(String.Format("| {0,-4}| {1,-20}| {2,-14:C2}| {3,-18}| {4,-14}|", this.ProductID, this.ProductName, this.ProductPrice, this.CubicCentimeters, this.TankCapacity));
            return info.ToString();
        }
        
    }
}
