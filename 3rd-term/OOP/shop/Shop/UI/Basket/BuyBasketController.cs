using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class BuyBasketController : IUserInterface
    {
        private readonly Basket Basket;
        private readonly User User;

        public BuyBasketController(User user, Basket basket)
        {
            User = user;
            Basket = basket;
        }

        public void Action()
        {
            Console.Clear();
            if (Basket.BasketSize() == 0)
            {
                Console.WriteLine("Basket is empty.. There is nothing to buy");
            }
            else
            {
                Basket.Display();
                Console.WriteLine($"{User.UserName} are you sure you want to buy products for {Basket.GetTotal():C2}? (y/n)");
                string response = Console.ReadLine().ToUpper();
                if (response.StartsWith("Y"))
                {
                    Basket.Buy();
                }
                else
                {
                    Console.WriteLine("Ok, keep surfing the shop");
                }
            }
            Console.ReadLine();
        }

        public string Message()
        {
            return "Buy basket";
        }
    }
}

