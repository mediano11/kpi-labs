using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class UserService : IService<User>
    {
        public DBContext _db { get; set; }
        public UserService(DBContext dBContext)
        {
            _db = dBContext;
        }
        public void Create(User user)
        {
            _db.Users.Add(user);
        }
        public void Remove(User user)
        {
            _db.Users.Remove(user);
        }

        public List<User> SelectAll()
        {
            return _db.Users;
        }
        public void UpdateMoney(int userID, decimal money)
        {
            _db.Users.Where(user => user.ID == userID).FirstOrDefault().Budget += money;

        }
        public List<User> SelectById(int id)
        {
            return _db.Users.Where(x => x.ID == id).ToList();
        }
    }
}
