using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class AddToBasketController : IUserInterface
    {
        private readonly User User;
        private readonly Basket Basket;
        private readonly IService<Product> ProductService;
        public AddToBasketController(User user, Basket basket, IService<Product> productService)
        {
            User = user;
            Basket = basket;
            ProductService = productService;
        }

        private void Show()
        {
            Console.WriteLine($"Your budget is {User.Budget:C2}");
            Utility.PrintProductTable(ProductService.SelectAll());
        }

        public void Action()
        {
            var productsList = ProductService.SelectAll();
            while (true)
            {
                Console.Clear();
                Show();
                Console.Write("Enter the product ID to see more information: (0 - to go back) ");
                int prodID = 0;
                bool valid = Int32.TryParse(Console.ReadLine(), out prodID);
                if (valid)
                {
                    if (prodID == 0) break;
                    var selectedProduct = productsList.FirstOrDefault(x => x.ProductID == prodID);
                    if (selectedProduct == null)
                    {
                        Console.WriteLine("Product not found.");
                    }
                    else
                    {
                        Console.Write(selectedProduct.toString());
                        Console.Write($"{User.UserName} would you like to add a(n) {selectedProduct.ProductName} for {selectedProduct.ProductPrice:C2} to your basket? (y/n) ");
                        string response = Console.ReadLine().ToUpper();

                        if (response.StartsWith("Y"))
                        {
                            Basket.AddToBasket(prodID);
                        } else
                        {
                            Console.WriteLine("Ok, keep surfing the shop");
                        }
                    }
                } else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
                Console.ReadKey();
            }
        }

        public string Message()
        {
            return "Add to basket";
        }
    }
}

