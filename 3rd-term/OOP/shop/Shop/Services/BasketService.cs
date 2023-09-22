using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class BasketService : IService<BasketItem>
    {
        public DBContext _db { get; set; }
        public BasketService(DBContext dBContext)
        {
            _db = dBContext;
        }
        public void Create(BasketItem basketItem)
        {
            _db.BasketItems.Add(basketItem);
        }
        public void Remove(BasketItem basketItem)
        {
            _db.BasketItems.Remove(basketItem);
        }
        public List<BasketItem> SelectAll()
        {
            return _db.BasketItems;
        }
        public List<BasketItem> SelectById(int id)
        {
            return _db.BasketItems.Where(x => x.CustomerID == id).ToList();
        }
    }
}
