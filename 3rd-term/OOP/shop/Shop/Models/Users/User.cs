using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class User
    {
        public int ID { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public decimal Budget { get; set; }
        public string Password { get; set; }
    }
}
