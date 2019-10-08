using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Automatic Properties *****");
            Car car = new Car("LADA", 55, "Red");
            car.DisplayStats();
        }
    }

    class Car
    {
        public string  PetName { get; set; }
        public int Speed { get; set; }
        public string  Color { get; set; }
        public Car() { }
        public Car(string name, int speed, string color)
        {
            PetName = name;
            Speed = speed;
            Color = color;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Car Name:{0}", PetName);
            Console.WriteLine("Speed:{0}", Speed);
            Console.WriteLine("Color:{0}", Color);
            Console.ReadLine();

        }
    }
}
