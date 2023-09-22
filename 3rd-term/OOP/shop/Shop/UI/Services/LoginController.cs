using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class LoginController : IUserInterface
    {
        private readonly DBContext _db;
        private readonly IService<User> UserService;

        public LoginController(DBContext db)
        {
            _db = db;
            UserService = new UserService(db);
        }


        public string Message()
        {
            return "Login";
        }

        public void Action()
        {
            var userInput = new User();
            Console.Clear();
            Console.Write("UserLogin: ");
            userInput.UserLogin = Console.ReadLine();

            Console.Write("Password: ");
            userInput.Password = Utility.CheckPassword();
            var user = UserService.SelectAll()
            .Where(el => el.UserLogin.Equals(userInput.UserLogin))
            .Where(el => el.Password.Equals(userInput.Password))
            .FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine("\nInvalid username or password.");
                Console.ReadLine();
                    
            } else
            {
                MainMenuController menuController = new MainMenuController(_db, user);
                menuController.Action();
            }   
        }
    }
}
