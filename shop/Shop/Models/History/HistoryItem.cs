using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class HistoryItem
    {
        public int ItemID { get; }
        public string ItemName { get; }
        public decimal ItemPrice { get; }

        public HistoryItem(int itemID, string itemName, decimal itemPrice)
        {
            ItemID = itemID;
            ItemName = itemName;
            ItemPrice = itemPrice;
        }
        public String toRow()
        {
            return String.Format("| {0,-8}| {1,-20}| {2,-12:C2}|", ItemID, ItemName, ItemPrice);
        }
    }
}
