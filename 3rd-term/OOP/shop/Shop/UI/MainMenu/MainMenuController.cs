using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class MainMenuController : IUserInterface
    {
        private readonly User User;
        private List<IUserInterface> UIs { get; set; }

        public MainMenuController(DBContext db, User user)
        {
            User = user;
            UIs = new List<IUserInterface>();
            UIs.Add(new DepositeController(user));
            UIs.Add(new ShopMenuController(db, user));
        }

        public string Message()
        {
            return "Exit";
        }
        public void Action()
        {
            while (true)
            {
                Show();
                int action = Utility.GetValidInput("your choice (0 - exit)", 0, UIs.Count);
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
            Console.WriteLine($"Login as {User.UserName} {User.UserSurname}");
            Console.WriteLine($"Your budget is {User.Budget:C2}");
            for (int i = 0; i < UIs.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + UIs[i].Message());
            }
        } 
    }
}
