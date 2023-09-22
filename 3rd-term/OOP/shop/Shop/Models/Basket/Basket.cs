using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
	public class Basket
	{
		private readonly User Customer;
		private IService<Product> ProductService;
		private IService<BasketItem> BasketService;
		private IService<History> HistoryService;
		private UserService UserService;

		public Basket(User user, DBContext db)
		{
			Customer = user;
			ProductService = new ProductService(db);
			BasketService = new BasketService(db);
			HistoryService = new HistoryService(db);
			UserService = new UserService(db);
		}
		
		public void AddToBasket(int id)
		{
			var basketItem = BasketService.SelectAll().SingleOrDefault(
				c => c.CustomerID == Customer.ID
				&& c.ProductID == id);
			if (basketItem == null)
			{               
				basketItem = new BasketItem
				{
					ProductID = id,
					CustomerID = Customer.ID,
					Product = ProductService.SelectAll().SingleOrDefault(
				   p => p.ProductID == id),
					DateCreated = DateTime.Now
				};

				BasketService.Create(basketItem);
				Console.WriteLine($"Item [{basketItem.ProductID}] {basketItem.Product.ProductName} successfully added to the basket.");
			}
			else
			{         
				Console.WriteLine("Item already in the basket!");
			}
		}
		public decimal GetTotal()
		{
			decimal? total = decimal.Zero;
			total = (decimal?)(from basketItems in CustomerBasket()
							   select basketItems.Product.ProductPrice).Sum();
			return total ?? decimal.Zero;
		}
		public void Buy()
		{
			if (Customer.Budget > GetTotal())
			{
				// clear shop
				if(ProductService.SelectAll().Any(el=> CustomerBasket().Any(x => x.ProductID == el.ProductID)))
				{
					ProductService.SelectAll().RemoveAll(el => CustomerBasket().Any(x => x.ProductID == el.ProductID));
				}
				else
                {
					Console.WriteLine("Unfortunately, the product is no longer in stock");
					BasketService.SelectAll().RemoveAll(el => CustomerBasket().Any(x => x.CustomerID == el.CustomerID));
					return;
					
                }
				// pay for products
				UserService.UpdateMoney(Customer.ID, -GetTotal());

				// add history
				List<HistoryItem> history = new List<HistoryItem> { };
				CustomerBasket().ForEach(el => history.Add(new HistoryItem(el.Product.ProductID, el.Product.ProductName, el.Product.ProductPrice)));
				HistoryService.Create(new History(Customer.ID,history, DateTime.Now));

				// clear basket
				BasketService.SelectAll().RemoveAll(el => CustomerBasket().Any(x => x.CustomerID == el.CustomerID));
				Console.WriteLine("Purchase completed successfully");
			} else
			{
				Console.WriteLine("Non-sufficient funds. :(");
			}
		}
		public void RemoveFromBasket(int id)
		{
			var basketItem = CustomerBasket().SingleOrDefault(x => x.ProductID == id);
			if (basketItem == null)
			{
				Console.WriteLine("Item not in the basket!");
				return;
			}
			else
			{
				BasketService.Remove(basketItem);
				Console.WriteLine($"Item [{basketItem.ProductID}] {basketItem.Product.ProductName} successfully deleted from basket.");
			}
		}
		public void Display()
        {
			Console.WriteLine($"{Customer.UserName}'s basket:");
			Utility.PrintBasketTable(CustomerBasket());
			Console.WriteLine($"Total sum: {GetTotal():C2}");
		}
		public int BasketSize()
        {
			return CustomerBasket().Count;
        }
		public List<BasketItem> CustomerBasket()
        {
			return BasketService.SelectById(Customer.ID);

		}
	}
}
