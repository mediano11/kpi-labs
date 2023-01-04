using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
	public class BasketItem
	{
		public Product Product { get; set; }
		public int ProductID { get; set; }
		public DateTime DateCreated { get; set; }
		public int CustomerID { get; set; }


		public String toRow()
		{
			return String.Format("| {0,-12}| {1,-12}| {2,-20}| {3,-14:C2}| {4,-24}|", this.CustomerID, this.ProductID, this.Product.ProductName, this.Product.ProductPrice, this.DateCreated);
		}
	}
}
