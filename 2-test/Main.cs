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

    class Programm 
    {
        static void Main()
        {
            Console.WriteLine("(owo)");
        }
    }
}