using System;

namespace Shop 
{

    class User {
        public string Name {get; private set;}
        public int Age {get; private set;}
        public string Phone_number {get; private set;}
        public double Balance {get; private set;}
        public double Spend {get; private set;}

        public User(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        public User(string Name, int Age, string Phone_number)
        {
            this.Name = Name;
            this.Age = Age;
            this.Phone_number = Phone_number;
        }
        public User(string Name, int Age, string Phone_number, double Balance)
        {
            this.Name = Name;
            this.Age = Age;
            this.Phone_number = Phone_number;
            this.Balance = Balance;
        }

        public void BalanceReplenishment (double balance)
        {
            Balance += balance;
        }
        public void ReduceBalance (double price) 
        {
            Balance -= price;
            Spend += price;
        }
    }

    class Product 
    {
        public string Name {get; set;}
        public double Price {get; set;}
        public string Manufacturer {get; set;}
        public double GetDiscountPrice(User user)
        {
            if (user.Spend < 1000)
            {
                return Price;
            }

            if (user.Spend < 5000)
            {
                return Price * 0.93;
            }

            return Price * 0.85;
        }

    }

    class Cloth : Product
    {
        public string Material { get; private set; }

        public Cloth(string name, int price, string manufacturer, string material)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            Material = material;
        }
    }

    class Fruits : Product
    {
        public string Variety { get; private set; }

        public Fruits(string name, int price, string manufacturer, string variety)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            Variety = variety;
        }
    }

    class Phone : Product
    {
        public string Size { get; private set; }
        public string OperatingSystem { get; private set; }
        public string CameraResolution { get; private set; } 

        public Phone(string name, int price, string manufacturer, string size, string operatingSystem, string cameraResolution)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            Size = size;
            OperatingSystem = operatingSystem;
            CameraResolution = cameraResolution;
        }
    }

    class Animal : Product
    {
        public string Type { get; private set;}

        public Animal(string name, int price, string manufacturer, string type)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            Type = type;
        }
    }

    class Informer 
    {
        public void Buy(User user, Product product)
        {
            double price = product.GetDiscountPrice(user);
            user.ReduceBalance(price);
            Console.WriteLine("user " + user.Name + " bought " + product.Name + " price " + price + "hryvnia");
        }
    }

    class Programm 
    {
        static void Main()
        {
            User user1 = new User(
                "Petro",
                21,
                "0985324950",
                34531.50
            );
            User user2 = new User(
                "Ivan",
                16,
                "0635814999",
                70
            );
            Console.WriteLine("price list:");
            Console.WriteLine("\n");
            Cloth tshirt = new Cloth(
                "tshirt",
                98,
                "Apple",
                "silk"
            ); 

            Console.WriteLine("name " + tshirt.Name);
            Console.WriteLine("price " + tshirt.Price);
            Console.WriteLine("manufacturer " + tshirt.Manufacturer);
            Console.WriteLine("material " + tshirt.Material);
            Console.WriteLine("\n");

            Fruits banana = new Fruits(
                "banana",
                14,
                "Africa",
                "honey banana"
            );

            Console.WriteLine("name " + banana.Name);
            Console.WriteLine("price " + banana.Price);
            Console.WriteLine("manufacturer " + banana.Manufacturer);
            Console.WriteLine("variety " + banana.Variety);
            Console.WriteLine("\n");

            Phone samsungGalaxy = new Phone(
                "Samsung Galaxy J-500H",
                5400,
                "USA",
                "10 cm x 24 cm",
                "Android 6.0.1",
                "15 Mp"
            );

            Console.WriteLine("name " + samsungGalaxy.Name);
            Console.WriteLine("price " + samsungGalaxy.Price);
            Console.WriteLine("manufacturer " + samsungGalaxy.Manufacturer);
            Console.WriteLine("size " + samsungGalaxy.Size);
            Console.WriteLine("Operatin system " + samsungGalaxy.OperatingSystem);
            Console.WriteLine("Camera resolution " + samsungGalaxy.CameraResolution);
            Console.WriteLine("\n");

            Animal cat = new Animal(
                "mursik",
                455,
                "Ukraine",
                "cat"
            );

            Console.WriteLine("name " + cat.Name);
            Console.WriteLine("price " + cat.Price);
            Console.WriteLine("manufacturer " + cat.Manufacturer);
            Console.WriteLine("Type " + cat.Type);
            Console.WriteLine("\n");


            Console.WriteLine("(owo)");
        }
    }
}