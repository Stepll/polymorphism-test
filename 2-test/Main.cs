using System;

namespace Shop 
{

    class User {
        public string Name {get; private set;}
        public int Age {get; private set;}
        public string Phone_number {get; private set;}
        public double Balance {get; private set;}
        public double Spend {get; private set;}

        public User()
        {
            this.Name = "null";
            this.Age = 18;
        }
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
        public virtual double GetDiscountPrice(User user)
        {
            if (user.Spend < 1000)
            {
                return Price;
            }

            if (user.Spend < 5000)
            {
                return Price * 0.93;
            }

            if (user.Spend < 20000)
            {
                return Price * 0.85;
            }

            return Price * 0.7;
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

        public override double GetDiscountPrice(User user)
        {
            return Price * 0.5;
        }
    }

    class Informer 
    {
        public void Buy(User user, Product product)
        {
            double price = product.GetDiscountPrice(user);
            user.ReduceBalance(price);
            Console.WriteLine("user " + user.Name + " bought " + product.Name + " price " + price + " hryvnia");
        }
    }

    class Programm 
    {
        static void Main()
        {
            Console.WriteLine("(owo)");

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
            
            Cloth tshirt = new Cloth(
                "tshirt",
                98,
                "Apple",
                "silk"
            ); 

            Fruits banana = new Fruits(
                "banana",
                14,
                "Africa",
                "honey banana"
            );            

            Phone samsungGalaxy = new Phone(
                "Samsung Galaxy J-500H",
                5400,
                "USA",
                "10 cm x 24 cm",
                "Android 6.0.1",
                "15 Mp"
            );

            Animal cat = new Animal(
                "mursik",
                455,
                "Ukraine",
                "cat"
            );

            User[] userlist = new User[] {
                user1,
                user2
            };

            Product[] products = new Product[] { // upcast
                tshirt,
                banana,
                samsungGalaxy,
                cat
            };

            User currentUser = null;

            Informer informer = new Informer();

            while(true) 
            {
                
                // currentUser = user1;
                // Console.WriteLine(currentUser.Name);
                // currentUser.Name = "null";
                // Console.WriteLine(currentUser.Name);
                // Console.WriteLine(user1.Name);
                string str = "";
                Console.Write("> ");
                str = Console.ReadLine();
                if (str == "exit") break;
                else if (str == "pricelist") 
                {
                    Console.WriteLine("price list:");
                    Console.WriteLine("\n");

                    Console.WriteLine("name " + tshirt.Name);
                    Console.WriteLine("price " + tshirt.Price);
                    Console.WriteLine("manufacturer " + tshirt.Manufacturer);
                    Console.WriteLine("material " + tshirt.Material);
                    Console.WriteLine("\n");

                    Console.WriteLine("name " + banana.Name);
                    Console.WriteLine("price " + banana.Price);
                    Console.WriteLine("manufacturer " + banana.Manufacturer);
                    Console.WriteLine("variety " + banana.Variety);
                    Console.WriteLine("\n");

                    Console.WriteLine("name " + samsungGalaxy.Name);
                    Console.WriteLine("price " + samsungGalaxy.Price);
                    Console.WriteLine("manufacturer " + samsungGalaxy.Manufacturer);
                    Console.WriteLine("size " + samsungGalaxy.Size);
                    Console.WriteLine("Operatin system " + samsungGalaxy.OperatingSystem);
                    Console.WriteLine("Camera resolution " + samsungGalaxy.CameraResolution);
                    Console.WriteLine("\n");

                    Console.WriteLine("name " + cat.Name);
                    Console.WriteLine("price " + cat.Price);
                    Console.WriteLine("manufacturer " + cat.Manufacturer);
                    Console.WriteLine("Type " + cat.Type);
                    Console.WriteLine("\n");
                }
                else if (str == "user")
                {
                    Console.Write("user name is ");
                    string userLog = Console.ReadLine();
                    for (int i = 0; i < userlist.Length; i++)
                    {
                        if (userlist[i].Name == userLog) 
                        {
                            currentUser = userlist[i];
                            Console.WriteLine("current user " + currentUser.Name);
                        } 
                        
                    }
                }
                else if (str == "userlist")
                {
                    for (int i = 0; i < userlist.Length; i++)
                    {
                        Console.WriteLine(userlist[i].Name);
                    }
                }
                else if (str == "currentuser") 
                {
                    if (currentUser == null) { Console.WriteLine("no current user"); }
                    else { Console.WriteLine(currentUser.Name); }

                }
                else if (str == "balance") 
                {
                    if (currentUser != null) 
                    {
                        Console.WriteLine(currentUser.Balance);
                    }
                    else
                    {
                        Console.WriteLine("no current user");
                    }
                }
                else if (str == "list") 
                {
                    for (int i = 0; i < products.Length; i++)
                    {
                        Console.WriteLine("product " + i + " " + products[i].Name + " price " + products[i].Price);
                    }
                }
                else if (str == "info")
                {
                    Console.Write("number product ");
                    string infoid = Console.ReadLine();
                    int infonumber = Convert.ToInt32(infoid);
                    // write info
                }
                else if (str == "buy")
                {
                    Console.Write("number product ");
                    string id = Console.ReadLine();
                    int productnumber = Convert.ToInt32(id);
                    if (productnumber >= 0 && productnumber < products.Length)
                    {
                        if (products[productnumber].Price < currentUser.Balance)
                        {
                            informer.Buy(currentUser, products[productnumber]);
                        }
                        else
                        {
                            Console.WriteLine("not enough money");
                        }
                    }
                    else
                    {
                        Console.WriteLine("its not product");
                    }
                }
                else if (str == "userinfo")
                {
                    Console.WriteLine("name " + currentUser.Name);
                    Console.WriteLine("age " + currentUser.Age);
                    Console.WriteLine("phone number " + currentUser.Phone_number);
                    Console.WriteLine("balance " + currentUser.Balance);
                    Console.WriteLine("spend " + currentUser.Spend);
                }
                else if (str == "help") {
                    Console.WriteLine("- exit");
                    Console.WriteLine("- pricelist");
                    Console.WriteLine("- user - switch user");
                    Console.WriteLine("- userlist");
                    Console.WriteLine("- currentuser - show name current user");
                    Console.WriteLine("- balance");
                    Console.WriteLine("- list - list with product numbers");
                    Console.WriteLine("- info - nothing");
                    Console.WriteLine("- buy - buy product");
                    Console.WriteLine("- userinfo");
                }
                else if (str == "addbalance") 
                {
                    Console.Write("add balance ");
                    string balancestr = Console.ReadLine();
                    int balance = Convert.ToInt32(balancestr);
                    currentUser.BalanceReplenishment(balance);
                }
                else 
                {
                    Console.WriteLine("Unknown command. Enter 'help' for information.");
                }
            }

            Console.Write("(uwu)");
        }
    }
}