using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class DBContext
    {
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<History> HistoryList { get; set; }

        public DBContext()
        {
            Users = new List<User>
            {
                new User() { ID = 1, UserLogin = "mediano", UserName = "Dima", UserSurname = "Pestenkov", Budget = 20000m, Password = "qwerty" },
                new User() { ID = 2, UserLogin = "admin", UserName = "admin", UserSurname = "admin",Budget = 9999999m, Password = "123456" },
            };
            Products = new List<Product>
            {
                new Car(1,"Mazda 6", 30470m, 227, 220, 2021),
                new Motorcycle(2,"Yamaha YZF-R1", 17399m, 998, 17),
                new Car(3,"Mazda 323", 4000m, 87, 220, 1998),
                new Motorcycle(4,"Kawasaki Vulcan S", 7199m, 649, 14),
                new Car(5,"Porsche 911 Turbo S", 270000m, 650, 330, 2020),
                new Motorcycle(6,"Honda Fury", 10599m, 1312, 13),
                new Car(7,"Audi RS5", 78800m, 450, 280, 2020),
                new Motorcycle(8,"Honda CB1000R", 12999m, 998, 16),
                new Car(9,"Audi RS7", 139500m, 600, 332, 2020),
                new Motorcycle(10,"Suzuki GSX-R1000R", 17495m, 100, 16),
                new Bicycle(11, "AUTHOR AVION 2023", 2508m, "Cyclocross Bike", 29, 20),
                new Bicycle(12, "GIANT ANTHEM 29 2", 24850m, "Mountain Bike", 29, 12),
                new Bicycle(13, "GIANT CONTEND AR 1", 1950m, "Road Bike", 28, 22),
                new Bicycle(14, "VERDE CADET", 245m, "BMX Bike", 20, 1),
                new Bicycle(15, "TREK FX Sport 5", 2122m, "Road Bike", 28, 11),
            };
            BasketItems = new List<BasketItem> { };
            HistoryList = new List<History> { };
        }
    }
}
