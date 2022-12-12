using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class DepositeController : IUserInterface
    {
        private readonly User User;

        public DepositeController(User user)
        {
            User = user;
        }

        public void Action()
        {
            Console.Clear();
            Console.WriteLine($"Your budget is {User.Budget:C2}");
            int amount = Utility.GetValidInput("the deposit amount", 0, 1000000);
            User.Budget += amount;
            Console.WriteLine($"The money has been successfully deposited. Your current balance is {User.Budget:C2}");
            Console.ReadKey();

        }

        public string Message()
        {
            return "Deposite money";
        }
    }
}
