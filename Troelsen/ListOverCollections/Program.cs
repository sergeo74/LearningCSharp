using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ListOverCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over Generic Collections *****\n");

            // Создать список Listo объектов Car.
            List<Car> myCars = new List<Car>()
            {
             new Car{Color = "Red",Make = "BMW",PetName = "Vasia",Speed = 100},
             new Car{Color = "Silver",Make = "Mersedes",PetName = "Vika",Speed = 110},
             new Car{Color = "Tan",Make = "Ford",PetName = "Vova",Speed = 90},
             new Car{Color = "Rust",Make = "BMW",PetName = "Mary",Speed = 10},
             new Car{Color = "Red",Make = "Yugo",PetName = "Va",Speed = 50}
            };
            GetFastCars(myCars);
            Console.ReadLine();
        }

        static void GetFastCars(List<Car> myCars)
        {
            // Найти быстрые автомобили BMW!
            var fastCar = myCars.Where(car => car.Make == "BMW" && car.Speed > 90);//from car in myCars where car.Speed > 90 && car.Make =="BMW" select car;
            foreach (var car in fastCar)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }
    }
}
