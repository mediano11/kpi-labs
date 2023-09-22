using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class RemoveFromBasketController : IUserInterface
    {
        private readonly Basket Basket;

        public RemoveFromBasketController(Basket basket)
        { 
            Basket = basket;
        }

        public void Action()
        {
            Console.Clear();
            if (Basket != null && Basket.BasketSize() > 0)
            {
                Console.WriteLine(Basket.BasketSize());
                Basket.Display();
                Console.WriteLine("Enter the product ID to delete from basket: ");
                int prodID = Convert.ToInt32(Console.ReadLine());
                Basket.RemoveFromBasket(prodID);
            }
            else
            {
                Console.WriteLine("Basket is empty.. There is nothing to remove");
            }
            Console.ReadLine();
        }

        public string Message()
        {
            return "Remove from basket";
        }
    }
}

