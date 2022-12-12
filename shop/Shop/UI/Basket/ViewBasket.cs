using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ViewBasket : IUserInterface
    {
        private readonly Basket Basket;
        private readonly User User;
        private List<IUserInterface> UIs { get; set; }

        public ViewBasket(User user, Basket basket)
        {
            User = user;
            Basket = basket;
            UIs = new List<IUserInterface>();
            UIs.Add(new RemoveFromBasketController(basket));
            UIs.Add(new BuyBasketController(user, basket));
        }

        private void Show()
        {
            Console.Clear();
            if (Basket!=null && Basket.BasketSize() > 0)
            {
                Basket.Display();
            } else
            {
                Console.WriteLine($"{User.UserName}, your basket is empty!");
            }
            for (int i = 0; i < UIs.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + UIs[i].Message());
            }

        }

        public void Action()
        {
            while (true)
            {
                Show();
                int action = Utility.GetValidInput("your choice (0 - to go back)", 0, UIs.Count);
                if(action == 0) break;
                else
                {
                    UIs[action - 1].Action();
                }
            }
        }

        public string Message()
        {
            return "View basket";
        }
    }
}

