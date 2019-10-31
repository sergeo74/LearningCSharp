using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Sorting *****");
            //Создать массив объектов Car
            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("Lada",80,1);
            myAutos[1] = new Car("Volga", 40, 234);
            myAutos[2] = new Car("BMW", 40, 34);
            myAutos[3] = new Car("Opel", 40, 4);
            myAutos[4] = new Car("GAZ", 40, 5);
            foreach (Car c in myAutos)
                Console.WriteLine("{0} {1}", c.CarID, c.PetName);
            Array.Sort(myAutos);//Сортирует по ID
            Console.WriteLine("\nHere is the ordered set of cars:");
            foreach (Car c in myAutos)
                Console.WriteLine("{0} {1}", c.CarID, c.PetName);
            //Array.Sort(myAutos, new PetNameComparer());//Сортирует PetName
            Array.Sort(myAutos, Car.SortByPetName); //Сортировка реализована через статическое св-во
            Console.WriteLine("\nOrdering by PetName:");
            foreach (Car c in myAutos)
                Console.WriteLine("{0} {1}", c.CarID, c.PetName);
            Console.ReadLine();
        }
    }
}
