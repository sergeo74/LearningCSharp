using System;

namespace BasicInheritans
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Basic Inheritance *****");
            Car car = new Car(80); //{ Speed= 100};
            car.Speed = 150;
            Console.WriteLine($"My car is going {car.Speed} MPH");
            MiniVan miniVan = new MiniVan();
            miniVan.Speed = 100;
            Console.WriteLine($"My van is going {miniVan.Speed} MPH");
            Console.ReadLine();
        }
    }
   
}
