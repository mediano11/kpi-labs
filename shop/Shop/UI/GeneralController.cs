using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class GeneralController
    {
        private List<IUserInterface> UIs { get; set; }
        public GeneralController()
        {
            DBContext db = new DBContext();
            UIs = new List<IUserInterface>();
            UIs.Add(new LoginController(db));
            UIs.Add(new ExitController());
     
    }
        private void Show()
        {
            Console.Clear();
            Console.WriteLine("\t\tWelcome to the Vehicle shop");
            for (int i = 0; i < UIs.Count; i++)
            {
                Console.WriteLine(i+1 + ". " + UIs[i].Message());
            }
        }
        private void Action()
        {

            int action = Utility.GetValidInput("your choice", 1, UIs.Count);
            UIs[action-1].Action();
        }

        public void Run()
        {
            while (true)
            {
                Show();
                Action();
            }
        }
    }
}
