using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ViewHistoryController : IUserInterface
    {
        private readonly User User;
        private readonly IService<History> HistoryService;

        public ViewHistoryController(User user, IService<History> historyService)
        {
            User = user;
            HistoryService = historyService;
        }

        private void Show()
        {
            Console.Clear();
            var history = HistoryService.SelectById(User.ID);
            if (history.Count > 0)
            {
                Utility.PrintHistory(history);
            } else
            {
                Console.WriteLine($"{User.UserName}, your shopping history is empty! Buy something to fill it.");
            }
        }

        public void Action()
        {
            Show();
            Console.ReadLine();
        }

        public string Message()
        {
            return "View history";
        }
    }
}

