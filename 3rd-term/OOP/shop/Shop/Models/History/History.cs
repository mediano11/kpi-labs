using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class History
    {
        private static int _historyID = 412543;
        public int HistoryID { get; }
        public int CustomerID { get; }
        public DateTime Date{ get; }
        public List<HistoryItem> HistoryItems { get; }
        public History(int customerID,List<HistoryItem> historyItems, DateTime date)
        {
            CustomerID = customerID;
            HistoryID = _historyID++;
            HistoryItems = historyItems;
            Date = date;
        }
    }
   
}
