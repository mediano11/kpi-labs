using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ExitController : IUserInterface
    { 
        public ExitController() { }

        public void Action()
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }

        public string Message()
        {
            return "Exit";
        }
    }
}
