using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Car : Product
    {
        public int MaxSpeed { get; }
        public int ProductionYear { get; }
        public int Horsepower { get; }

        public Car(int productID, string productName, decimal productPrice, int horsepower, int maxSpeed, int productionYear) : base(productID, productName, productPrice)
        {
            MaxSpeed = maxSpeed;
            ProductionYear = productionYear;
            Horsepower = horsepower;
        }

        public override String toString()
        {
            var info = new StringBuilder();
            info.AppendLine(String.Format("| {0,-4}| {1,-20}| {2,-14:C2}| {3,-10}| {4,-16}|", "ID","Car name", "Price", "Max speed", "Production year"));
            info.AppendLine(String.Format("| {0,-4}| {1,-20}| {2,-14:C2}| {3,-10}| {4,-16}|", this.ProductID, this.ProductName, this.ProductPrice, this.MaxSpeed, this.ProductionYear));
            return info.ToString();
        }
    }
}
