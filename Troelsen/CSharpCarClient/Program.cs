using CarLibrary;
using System;

namespace CSharpCarClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** * C# CarLibrary Client App *****");

            // Создать объект SportsCar.
            SportCar viper = new SportCar("Viper", 240, 40);
            //Type type = viper.GetType();
            //Type type = typeof(SportCar);
            Type type = Type.GetType("CarLibrary.SportCar, CarLibrary", false, true);
            Console.WriteLine(type);
            Console.ReadLine();
            viper.TurboBoost();

            // Создать объект MiniVan.
            MiniVan miniVan = new MiniVan();
            miniVan.TurboBoost();

            Console.WriteLine("Done . Press any key to terminate");
            Console.ReadKey();
        }
    }
}
