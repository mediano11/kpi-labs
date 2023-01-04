using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ShopMenuController : IUserInterface
    {
        private List<IUserInterface> UIs { get; set; }
        private readonly IService<Product> ProductService;
        private readonly IService<History> HistoryService;

        public ShopMenuController(DBContext db, User user)
        {
            HistoryService = new HistoryService(db);
            ProductService = new ProductService(db);
            Basket basket = new Basket(user,db);
            UIs = new List<IUserInterface>();
            UIs.Add(new AddToBasketController(user, basket, ProductService));
            UIs.Add(new ViewBasket(user,basket));
            UIs.Add(new ViewHistoryController(user, HistoryService));
        }
        public void Action()
        {
            while (true)
            {
                
                Show();
                int action = Utility.GetValidInput("your choice (0 - to go back)", 0, UIs.Count);
                if (action == 0) break;
                else
                {
                    UIs[action - 1].Action();
                }
            }

        }
        private void Show()
        {
            
            Console.Clear();
            Console.WriteLine("\t\tVehicle shop");
            var productList = ProductService.SelectAll();
            if (productList.Count > 0)
            {
                Utility.PrintProductTable(productList);
            } else
            {
                Console.WriteLine("Shop is empty.... Please, come back later");
            }
            for (int i = 0; i < UIs.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + UIs[i].Message());
            }
        }

        public string Message()
        {
            return "Visit shop";
        }
    }
}
