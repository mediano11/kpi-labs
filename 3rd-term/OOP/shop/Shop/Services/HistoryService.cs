using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class HistoryService : IService<History>
    {
        public DBContext _db { get; set; }
        public HistoryService(DBContext dBContext)
        {
            _db = dBContext;
        }
        public void Create(History history)
        {
            _db.HistoryList.Add(history);
        }
        public void Remove(History historyItem)
        {
            _db.HistoryList.Remove(historyItem);
        }

        public List<History> SelectAll()
        {
            return _db.HistoryList;
        }
        public List<History> SelectById(int id)
        {
            return _db.HistoryList.Where(x => x.CustomerID == id).ToList();
        }

        
    }
}
