using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public interface IService<T>
    {
        void Create(T item);
        void Remove(T item);
        List<T> SelectAll();
        List<T> SelectById(int id);
    }
}
