using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class ProductService : IService<Product>
    {
        public DBContext _db { get; set; }
        public ProductService(DBContext dBContext)
        {
            _db = dBContext;
        }
        public void Create(Product product)
        {
            _db.Products.Add(product);
        }
        public void Remove(Product product)
        {
            _db.Products.Remove(product);
        }
        public List<Product> SelectAll()
        {
            return _db.Products;
        }
        public List<Product> SelectById(int id)
        {
            return _db.Products.Where(x => x.ProductID == id).ToList();
        }
    }
}
