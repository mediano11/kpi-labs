using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Bicycle : Product
    {
        public string BicycleType { get; }
        public int WheelDiametr { get; }
        public int SpeedsNumber { get; }
        private string productType = "Bicylce"; 

        public Bicycle(int productID, string productName, decimal productPrice, string bicycleType, int wheelDiametr, int speedsNumber) : base(productID, productName, productPrice)
        {
            BicycleType = bicycleType;
            WheelDiametr = wheelDiametr;
            SpeedsNumber = speedsNumber;
        }

        public override String toString()
        {
            var info = new StringBuilder();
            info.AppendLine(String.Format("| {0,-4}| {1,-20}| {2,-14:C2}| {3,-18}| {4,-14}| {5,-16}|", "ID", "Bicycle name", "Price", "Bicycle type", "Wheel diametr", "Number of speeds"));
            info.AppendLine(String.Format("| {0,-4}| {1,-20}| {2,-14:C2}| {3,-18}| {4,-14}| {5,-16}|", this.ProductID, this.ProductName, this.ProductPrice, this.BicycleType, this.WheelDiametr, this.SpeedsNumber));
            return info.ToString();
        }
        public override String toRow()
        {
            return String.Format("| {0,-12}| {1,-14}|{2,20} |{3,14:C2} |", this.ProductID, this.productType, this.ProductName, this.ProductPrice);
        }
    }
}

/*Road Bike.
Mountain Bike.
Touring Bike.
Track Bike.
Cyclocross Bike
BMX.
Electric Bike*/
