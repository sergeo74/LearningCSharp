using System;

namespace AutoProps
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Automatic Properties *****");
            var car = new Car("LADA", 55, "Red");
            car.DisplayStats();
            Console.ReadLine();
            var g = new Garage();
            g.MyAuto = car;
            Console.WriteLine("Number of Cars in Garage: {0}", g.NumberOfCar);
            Console.WriteLine("Name of My Car in Garage: {0}", g.MyAuto.PetName);
            Console.ReadLine();
        }
    }

    internal class Car
    {
        public Car()
        {
        }

        public Car(string name, int speed, string color)
        {
            PetName = name;
            Speed = speed;
            Color = color;
        }

        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }

        public void DisplayStats()
        {
            Console.WriteLine("Car Name:{0}", PetName);
            Console.WriteLine("Speed:{0}", Speed);
            Console.WriteLine("Color:{0}", Color);
        }
    }

    internal class Garage
    {
        public Garage()
        {
        }

        public Garage(int number, Car car)
        {
            NumberOfCar = number;
            MyAuto = car;
        }

        public int NumberOfCar { get; set; } = 1;
        public Car MyAuto { get; set; } = new Car();
    }
}