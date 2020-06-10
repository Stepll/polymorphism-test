using System;

namespace Shop 
{
    class Product 
    {
        public string Name;
        public int price;

        public virtual void getInfo()
        {
            Console.WriteLine("product " + Name + "\nprice " + price + "\nnull");
        }
    }

    class Phone : Product 
    {
        public override void getInfo()
        {
            Console.WriteLine("phone name " + Name + "\nprice " + price + "\nggwp");
        }
    }

    class Cat : Product 
    {
        public override void getInfo()
        {
            Console.WriteLine("cat name " + Name + "\nprice " + price + "\nnyan(owo)");
        }
    }

    class Apple : Product
    {
        public override void getInfo()
        {
            Console.WriteLine("product apple " + Name + "\nprice " + price + "\nbad apple!");
        }
    }

    

    class Programm 
    {
        static void Main()
        {
            Product[] product = new Product[3];
            

            Phone phone = new Phone();
            phone.Name = "samsung";
            phone.price = 10000;

            Cat cat = new Cat();
            cat.Name = "mursik";
            cat.price = 400;

            Apple apple = new Apple();
            apple.Name = "golden";
            apple.price = 6;

            product[0] = phone;
            product[1] = cat;
            product[2] = apple;

            for (int i = 0; i < product.Length; i++) {
                product[i].getInfo();
            }  

            Console.WriteLine("okey");
        }
    }
}